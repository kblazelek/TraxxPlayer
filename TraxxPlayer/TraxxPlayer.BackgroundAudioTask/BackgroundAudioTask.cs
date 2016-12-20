//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************
using System;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.Media;
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Collections.Generic;
using Windows.Foundation;
using TraxxPlayer.Common.Messages;
using Windows.Storage.Streams;
using TraxxPlayer.Common.Enums_and_constants;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Common.Helpers;

namespace TraxxPlayer.BackgroundAudioTask
{
    public sealed class BackgroundAudioTask : IBackgroundTask
    {
        #region Private fields, properties
        private const string TrackIdKey = "trackid";
        private const string TitleKey = "title";
        private const string AlbumArtKey = "albumart";
        private SystemMediaTransportControls smtc;
        private MediaPlaybackList playbackList = new MediaPlaybackList();
        private BackgroundTaskDeferral deferral;
        private AppState foregroundAppState = AppState.Unknown;
        private ManualResetEvent backgroundTaskStarted = new ManualResetEvent(false);
        private bool playbackStartedPreviously = false;
        #endregion

        #region Helper methods
        Uri GetCurrentTrackId()
        {
            if (playbackList == null)
                return null;

            return GetTrackId(playbackList.CurrentItem);
        }

        Uri GetTrackId(MediaPlaybackItem item)
        {
            if (item == null)
                return null;
            string trackIdKey = item.Source.CustomProperties[TrackIdKey].ToString();
            return new Uri(trackIdKey);
        }
        #endregion

        #region IBackgroundTask and IBackgroundTaskInstance Interface Members and handlers
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Background Audio Task " + taskInstance.Task.Name + " starting...");

            // Initialize SystemMediaTransportControls (SMTC) for integration with
            // the Universal Volume Control (UVC).
            //
            // The UI for the UVC must update even when the foreground process has been terminated
            // and therefore the SMTC is configured and updated from the background task.
            smtc = BackgroundMediaPlayer.Current.SystemMediaTransportControls;
            smtc.ButtonPressed += smtc_ButtonPressed;
            smtc.PropertyChanged += smtc_PropertyChanged;
            smtc.IsEnabled = true;
            smtc.IsPauseEnabled = true;
            smtc.IsPlayEnabled = true;
            smtc.IsNextEnabled = true;
            smtc.IsPreviousEnabled = true;

            // Read persisted state of foreground app
            var value = ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.AppState);
            if (value == null)
                foregroundAppState = AppState.Unknown;
            else
                foregroundAppState = EnumHelper.Parse<AppState>(value.ToString());

            // Add handlers for MediaPlayer
            BackgroundMediaPlayer.Current.CurrentStateChanged += Current_CurrentStateChanged;

            // Initialize message channel 
            BackgroundMediaPlayer.MessageReceivedFromForeground += BackgroundMediaPlayer_MessageReceivedFromForeground;

            // Send information to foreground that background task has been started if app is active
            if (foregroundAppState != AppState.Suspended)
                MessageService.SendMessageToForeground(new BackgroundAudioTaskStartedMessage());

            ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.BackgroundTaskState, BackgroundTaskState.Running.ToString());

            deferral = taskInstance.GetDeferral(); // This must be retrieved prior to subscribing to events below which use it

            // Mark the background task as started to unblock SMTC Play operation (see related WaitOne on this signal)
            backgroundTaskStarted.Set();

            // Associate a cancellation and completed handlers with the background task.
            taskInstance.Task.Completed += TaskCompleted;
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled); // event may raise immediately before continung thread excecution so must be at the end
        }

        /// <summary>
        /// Indicate that the background task is completed.
        /// </summary>       
        void TaskCompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            Debug.WriteLine("BackgroundAudioTask " + sender.TaskId + " Completed...");
            deferral.Complete();
        }

        /// <summary>
        /// Handles background task cancellation. Task cancellation happens due to:
        /// 1. Another Media app comes into foreground and starts playing music 
        /// 2. Resource pressure. Your task is consuming more CPU and memory than allowed.
        /// In either case, save state so that if foreground app resumes it can know where to start.
        /// </summary>
        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            // You get some time here to save your state before process and resources are reclaimed
            Debug.WriteLine("BackgroundAudioTask " + sender.Task.TaskId + " Cancel Requested...");
            try
            {
                // immediately set not running
                backgroundTaskStarted.Reset();

                // save state
                ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.TrackId, GetCurrentTrackId() == null ? null : GetCurrentTrackId().ToString());
                //ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.Position, BackgroundMediaPlayer.Current.Position.ToString());
                ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.BackgroundTaskState, BackgroundTaskState.Canceled.ToString());
                ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.AppState, Enum.GetName(typeof(AppState), foregroundAppState));

                // unsubscribe from list changes
                if (playbackList != null)
                {
                    playbackList.CurrentItemChanged -= PlaybackList_CurrentItemChanged;
                    playbackList = null;
                }

                // unsubscribe event handlers
                BackgroundMediaPlayer.MessageReceivedFromForeground -= BackgroundMediaPlayer_MessageReceivedFromForeground;
                smtc.ButtonPressed -= smtc_ButtonPressed;
                smtc.PropertyChanged -= smtc_PropertyChanged;

                BackgroundMediaPlayer.Shutdown(); // shutdown media pipeline
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            deferral.Complete(); // signals task completion. 
            Debug.WriteLine("BackgroundAudioTask Cancel complete...");
        }
        #endregion

        #region SysteMediaTransportControls related functions and handlers
        /// <summary>
        /// Update Universal Volume Control (UVC) using SystemMediaTransPortControl APIs
        /// </summary>
        private void UpdateUVCOnNewTrack(MediaPlaybackItem item)
        {
            if (item == null)
            {
                smtc.PlaybackStatus = MediaPlaybackStatus.Stopped;
                smtc.DisplayUpdater.MusicProperties.Title = string.Empty;
                smtc.DisplayUpdater.Thumbnail = null;
                smtc.IsEnabled = false;
                smtc.DisplayUpdater.Update();
                return;
            }

            smtc.PlaybackStatus = MediaPlaybackStatus.Playing;
            smtc.DisplayUpdater.Type = MediaPlaybackType.Music;
            smtc.DisplayUpdater.MusicProperties.Title = item.Source.CustomProperties[TitleKey] as string;

            string s = item.Source.CustomProperties["albumart"] as string;
            var albumArtUri = new Uri(item.Source.CustomProperties[AlbumArtKey].ToString());
            if (albumArtUri != null)
                smtc.DisplayUpdater.Thumbnail = RandomAccessStreamReference.CreateFromUri(albumArtUri);
            else
                smtc.DisplayUpdater.Thumbnail = null;

            smtc.DisplayUpdater.Update();
        }

        /// <summary>
        /// Fires when any SystemMediaTransportControl property is changed by system or user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void smtc_PropertyChanged(SystemMediaTransportControls sender, SystemMediaTransportControlsPropertyChangedEventArgs args)
        {
            // TODO: If soundlevel turns to muted, app can choose to pause the music
        }

        /// <summary>
        /// This function controls the button events from UVC.
        /// This code if not run in background process, will not be able to handle button pressed events when app is suspended.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void smtc_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    Debug.WriteLine("UVC play button pressed");

                    // When the background task has been suspended and the SMTC
                    // starts it again asynchronously, some time is needed to let
                    // the task startup process in Run() complete.

                    // Wait for task to start. 
                    // Once started, this stays signaled until shutdown so it won't wait
                    // again unless it needs to.
                    bool result = backgroundTaskStarted.WaitOne(5000);
                    if (!result)
                        throw new Exception("Background Task didnt initialize in time");

                    StartPlayback();
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    Debug.WriteLine("UVC pause button pressed");
                    try
                    {
                        BackgroundMediaPlayer.Current.Pause();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                    break;
                case SystemMediaTransportControlsButton.Next:
                    Debug.WriteLine("UVC next button pressed");
                    SkipToNext();
                    break;
                case SystemMediaTransportControlsButton.Previous:
                    Debug.WriteLine("UVC previous button pressed");
                    SkipToPrevious();
                    break;
            }
            MessageService.SendMessageToForeground(new UVCButtonPressedMessage(args.Button));
        }



        #endregion

        #region Playlist management functions and handlers
        /// <summary>
        /// Start playlist and change UVC state
        /// </summary>
        private void StartPlayback()
        {
            //try
            //{
            //    // If playback was already started once we can just resume playing.
            //    if (!playbackStartedPreviously)
            //    {
            //        playbackStartedPreviously = true;

            //        // If the task was cancelled we would have saved the current track and its position. We will try playback from there.
            //        //var currentTrackId = ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.TrackId);
            //        //var currentTrackPosition = ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.Position);
            //        if (currentTrackId != null)
            //        {
            //            // Find the index of the item by name
            //            var index = playbackList.Items.ToList().FindIndex(item =>
            //                GetTrackId(item).ToString() == (string)currentTrackId);

            //            //if (currentTrackPosition == null)
            //            //{
            //                // Play from start if we dont have position
            //                Debug.WriteLine("StartPlayback: Switching to track " + index);
            //                playbackList.MoveTo((uint)index);

            //                // Begin playing
            //                BackgroundMediaPlayer.Current.Play();
            //            //}
            //            //else
            //            //{
            //            //    // Play from exact position otherwise
            //            //    TypedEventHandler<MediaPlaybackList, CurrentMediaPlaybackItemChangedEventArgs> handler = null;
            //            //    handler = (MediaPlaybackList list, CurrentMediaPlaybackItemChangedEventArgs args) =>
            //            //    {
            //            //        if (args.NewItem == playbackList.Items[index])
            //            //        {
            //            //            // Unsubscribe because this only had to run once for this item
            //            //            playbackList.CurrentItemChanged -= handler;

            //            //            // Set position
            //            //            var position = TimeSpan.Parse((string)currentTrackPosition);
            //            //            Debug.WriteLine("StartPlayback: Setting Position " + position);
            //            //            BackgroundMediaPlayer.Current.Position = position;

            //            //            // Begin playing
            //            //            BackgroundMediaPlayer.Current.Play();
            //            //        }
            //            //    };
            //            //    playbackList.CurrentItemChanged += handler;

            //            //    // Switch to the track which will trigger an item changed event
            //            //    Debug.WriteLine("StartPlayback: Switching to track " + index);
            //            //    playbackList.MoveTo((uint)index);
            //            //}
            //        }
            //        else
            //        {
            //            // Begin playing
            //            BackgroundMediaPlayer.Current.Play();
            //        }
            //    }
            //    else
            //    {
            //        // Begin playing
            //        BackgroundMediaPlayer.Current.Play();
            //    }
            //}
            try
            {
                BackgroundMediaPlayer.Current.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Raised when playlist changes to a new track
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void PlaybackList_CurrentItemChanged(MediaPlaybackList sender, CurrentMediaPlaybackItemChangedEventArgs args)
        {
            // Get the new item
            var item = args.NewItem;
            Debug.WriteLine("PlaybackList_CurrentItemChanged: " + (item == null ? "null" : Convert.ToString(GetTrackId(item))));

            // Update the system view
            UpdateUVCOnNewTrack(item);

            // Get the current track
            Uri currentTrackId = null;
            if (item != null)
            {
                string trackIdKey = item.Source.CustomProperties[TrackIdKey].ToString();
                currentTrackId = new Uri(trackIdKey);
            }

            ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.TrackId, currentTrackId == null ? null : currentTrackId.ToString());
            MessageService.SendMessageToForeground(new TrackChangedMessage(currentTrackId));
        } // Sprawdzone

        /// <summary>
        /// Skip track and update UVC via SMTC
        /// </summary>
        private void SkipToPrevious() // Sprawdzone
        {
            smtc.PlaybackStatus = MediaPlaybackStatus.Changing;
            playbackList.MovePrevious();

            // TODO: Work around playlist bug that doesn't continue playing after a switch; remove later
            //BackgroundMediaPlayer.Current.Play();
        }

        /// <summary>
        /// Skip track and update UVC via SMTC
        /// </summary>
        private void SkipToNext() // Sprawdzone
        {
            smtc.PlaybackStatus = MediaPlaybackStatus.Changing;
            playbackList.MoveNext();

            // TODO: Work around playlist bug that doesn't continue playing after a switch; remove later
            //BackgroundMediaPlayer.Current.Play();

        }
        #endregion

        #region Background Media Player Handlers
        void Current_CurrentStateChanged(MediaPlayer sender, object args) // Sprawdzone
        {
            if (sender.CurrentState == MediaPlayerState.Playing)
            {
                smtc.PlaybackStatus = MediaPlaybackStatus.Playing;
            }
            else if (sender.CurrentState == MediaPlayerState.Paused)
            {
                smtc.PlaybackStatus = MediaPlaybackStatus.Paused;
            }
            else if (sender.CurrentState == MediaPlayerState.Closed)
            {
                smtc.PlaybackStatus = MediaPlaybackStatus.Closed;
            }
        }

        /// <summary>
        /// Raised when a message is recieved from the foreground app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BackgroundMediaPlayer_MessageReceivedFromForeground(object sender, MediaPlayerDataReceivedEventArgs e)
        {
            AppSuspendedMessage appSuspendedMessage;
            if (MessageService.TryParseMessage(e.Data, out appSuspendedMessage))
            {
                Debug.WriteLine("App suspending"); // App is suspended, you can save your task state at this point
                foregroundAppState = AppState.Suspended;
                var currentTrackId = GetCurrentTrackId();
                ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.TrackId, currentTrackId == null ? null : currentTrackId.ToString());
                return;
            }

            AppResumedMessage appResumedMessage;
            if (MessageService.TryParseMessage(e.Data, out appResumedMessage))
            {
                Debug.WriteLine("App resuming"); // App is resumed, now subscribe to message channel
                foregroundAppState = AppState.Active;
                return;
            }

            //currentTrackId = GetCurrentTrackId();
            //ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.TrackId, currentTrackId == null ? null : currentTrackId.ToString());
            StartPlaybackMessage startPlaybackMessage;
            if (MessageService.TryParseMessage(e.Data, out startPlaybackMessage))
            {
                //Foreground App process has signalled that it is ready for playback
                Debug.WriteLine("Starting Playback");
                StartPlayback();
                return;
            }

            SkipNextMessage skipNextMessage;
            if (MessageService.TryParseMessage(e.Data, out skipNextMessage))
            {
                // User has chosen to skip track from app context.
                Debug.WriteLine("Skipping to next");
                SkipToNext();
                return;
            }

            SkipPreviousMessage skipPreviousMessage;
            if (MessageService.TryParseMessage(e.Data, out skipPreviousMessage))
            {
                // User has chosen to skip track from app context.
                Debug.WriteLine("Skipping to previous");
                SkipToPrevious();
                return;
            }

            DeleteTrackFromPlaybackList deleteTrackFromPlaybackList;
            if (MessageService.TryParseMessage(e.Data, out deleteTrackFromPlaybackList))
            {
                DeleteTrackFromPlaybackList(deleteTrackFromPlaybackList.Track.stream_url.ToString());
                return;
            }

            TrackChangedMessage trackChangedMessage;
            if (MessageService.TryParseMessage(e.Data, out trackChangedMessage))
            {
                var index = playbackList.Items.ToList().FindIndex(i => new Uri(i.Source.CustomProperties[TrackIdKey].ToString()) == trackChangedMessage.TrackId);
                Debug.WriteLine("Skipping to track " + index);
                smtc.PlaybackStatus = MediaPlaybackStatus.Changing;
                playbackList.MoveTo((uint)index);

                // TODO: Work around playlist bug that doesn't continue playing after a switch; remove later
                //BackgroundMediaPlayer.Current.Play();
                return;
            }

            UpdatePlaylistMessage updatePlaylistMessage;
            if (MessageService.TryParseMessage(e.Data, out updatePlaylistMessage))
            {
                CreatePlaybackListAndStartPlaying(updatePlaylistMessage.Songs);
                return;
            }

            ShutdownBackgroundMediaPlayer shutdownBackgroundMediaPlayer;
            if (MessageService.TryParseMessage(e.Data, out shutdownBackgroundMediaPlayer))
            {
                UpdateUVCOnNewTrack(null);
                if (playbackList != null)
                {
                    playbackList.CurrentItemChanged -= PlaybackList_CurrentItemChanged;
                    playbackList = null;
                }

                BackgroundMediaPlayer.Shutdown();
                return;
            }
        }

        void DeleteTrackFromPlaybackList(string stream_url)
        {
            Debug.WriteLine($"BackgroundAudioTask.DeleteTrackFromPlaybackList: Deleting track {stream_url} from playback list.");
            //MessageService.SendMessageToForeground(new PlaybackListEmptyMessage());
            var mediaPlaybackItem = playbackList.Items.Where(mpi => mpi.Source.CustomProperties[TrackIdKey].ToString() == stream_url).FirstOrDefault();
            if (mediaPlaybackItem != null)
            {
                playbackList.Items.Remove(mediaPlaybackItem);
                if (playbackList.Items.Count == 0)
                {
                    if (playbackList != null)
                    {
                        playbackList.CurrentItemChanged -= PlaybackList_CurrentItemChanged;
                        playbackList = null;
                    }
                    BackgroundMediaPlayer.Current.Pause();
                    // Inform foreground that playback list is empty
                    MessageService.SendMessageToForeground(new PlaybackListEmptyMessage());
                }
            }
            else
            {
                throw new Exception($"There is no track in current playback list with stream_url {stream_url}");
            }
        }
        /// <summary>
        /// Create a playback list from the list of tracks received from the foreground app and starts playing.
        /// </summary>
        /// <param name="tracks"></param>
        void CreatePlaybackListAndStartPlaying(IEnumerable<SoundCloudTrack> tracks)
        {
            // Remove handler for item changes from current playback list
            if (playbackList != null)
            {
                playbackList.CurrentItemChanged -= PlaybackList_CurrentItemChanged;
                playbackList = null;
            }

            // Create a new list and enable looping
            playbackList = new MediaPlaybackList();
            playbackList.AutoRepeatEnabled = true;

            // Check if tracks collection is empty
            if (tracks == null)
            {
                throw new Exception("Cannot create playlist from empty list of tracks. Create playback list failed.");
            }
            else if (tracks.Count() == 0)
            {
                throw new Exception("Cannot create playlist from empty list of tracks. Create playback list failed.");
            }

            // Add tracks to the new playback list
            foreach (var song in tracks)
            {
                if (!string.IsNullOrEmpty(song.stream_url))
                {
                    var source = MediaSource.CreateFromUri(new Uri(song.stream_url.ToString()));
                    source.CustomProperties[TrackIdKey] = song.stream_url.ToString();
                    source.CustomProperties[TitleKey] = song.title;
                    source.CustomProperties[AlbumArtKey] = song.AlbumArtUri;
                    playbackList.Items.Add(new MediaPlaybackItem(source));
                }
            }

            // Check if playback list contains valid tracks
            if (playbackList.Items.Count == 0)
            {
                throw new Exception("Cannot create playlist, because passed tracks are not valid. Create playback list failed.");
            }

            // Enable AutoPlay
            BackgroundMediaPlayer.Current.AutoPlay = true;

            // Assign the list to the player
            BackgroundMediaPlayer.Current.Source = playbackList;

            // Add handler for future playlist item changes
            playbackList.CurrentItemChanged += PlaybackList_CurrentItemChanged;
        }
        #endregion
    }
}
