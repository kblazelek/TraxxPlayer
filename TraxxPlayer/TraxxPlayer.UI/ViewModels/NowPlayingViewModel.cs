﻿using BackgroundAudioShared;
using BackgroundAudioShared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Media;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.UI.ViewModels
{
    public class NowPlayingViewModel : CommonViewModel
    {
        private bool isMyBackgroundTaskRunning = false;
        private AutoResetEvent backgroundAudioTaskStarted;
        #region private
        private ImageSource _albumImage;
        private ImageSource _playPauseImage;
        private string _songName;
        private string _albumTitle;
        #endregion
        public ImageSource AlbumImage
        {
            get
            {
                return _albumImage;
            }
            set
            {
                _albumImage = value;
                OnPropertyChanged(nameof(AlbumImage));
            }
        }
        public ImageSource PlayPauseImage
        {
            get { return _playPauseImage; }
            set { _playPauseImage = value; OnPropertyChanged(nameof(PlayPauseImage)); }
        }
        public string SongName
        {
            get
            {
                return _songName;
            }
            set
            {
                _songName = value;
                OnPropertyChanged(nameof(SongName));
            }
        }
        public string AlbumTitle
        {
            get
            {
                return _albumTitle;
            }
            set
            {
                _albumTitle = value;
                OnPropertyChanged(nameof(AlbumTitle));
            }
        }
        public NowPlayingViewModel()
        {
            AlbumImage = new BitmapImage(new Uri(@"ms-appx:///Assets/Albumart.png"));
        }

        /// <summary>
        /// Gets the information about background task is running or not by reading the setting saved by background task.
        /// This is used to determine when to start the task and also when to avoid sending messages.
        /// </summary>
        private bool IsMyBackgroundTaskRunning
        {
            get
            {
                if (isMyBackgroundTaskRunning)
                    return true;

                string value = ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.BackgroundTaskState) as string;
                if (value == null)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        isMyBackgroundTaskRunning = EnumHelper.Parse<BackgroundTaskState>(value) == BackgroundTaskState.Running;
                    }
                    catch (ArgumentException)
                    {
                        isMyBackgroundTaskRunning = false;
                    }
                    return isMyBackgroundTaskRunning;
                }
            }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            backgroundAudioTaskStarted = new AutoResetEvent(false);

            if (!IsMyBackgroundTaskRunning)
            {
                PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Play.png"));
                StartBackgroundAudioTask();
            }
            else
            {
                //Start playback if Paused.
                if (MediaPlayerState.Paused == BackgroundMediaPlayer.Current.CurrentState)
                {
                    BackgroundMediaPlayer.Current.Play();
                    PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Pause.png"));
                }
                else if (MediaPlayerState.Closed == BackgroundMediaPlayer.Current.CurrentState)
                {
                    StartBackgroundAudioTask();
                }
            }
            var trackId = GetCurrentTrackId();
            if (trackId != null)
            {
                //TODO: Dodać obsługę playlisty zamiast likes
                var song = App.likes.Where(t => t.stream_url == trackId.ToString()).FirstOrDefault();
                if (song != null)
                {
                    LoadTrack(song);
                }
            }
            return base.OnNavigatedToAsync(parameter, mode, state);

        }

        private void StartBackgroundAudioTask()
        {
            AddMediaPlayerEventHandlers();
            var startResult = CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                bool result = backgroundAudioTaskStarted.WaitOne(10000);
                //Send message to initiate playback
                if (result == true)
                {
                    MessageService.SendMessageToBackground(new UpdatePlaylistMessage(App.likes));
                    MessageService.SendMessageToBackground(new StartPlaybackMessage());
                    PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Pause.png"));
                }
                else
                {
                    throw new Exception("Background Audio Task didn't start in expected time");
                }
            });
        }

        private void AddMediaPlayerEventHandlers()
        {
            BackgroundMediaPlayer.MessageReceivedFromBackground += this.BackgroundMediaPlayer_MessageReceivedFromBackground;
        }



        async void BackgroundMediaPlayer_MessageReceivedFromBackground(object sender, MediaPlayerDataReceivedEventArgs e)
        {
            TrackChangedMessage trackChangedMessage;
            if (MessageService.TryParseMessage(e.Data, out trackChangedMessage))
            {
                // When foreground app is active change track based on background message
                await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var songIndex = GetSongIndexById(trackChangedMessage.TrackId);
                    if (songIndex >= 0)
                    {
                        var song = App.likes[songIndex];
                        LoadTrack(song); //Update UI
                    }
                });
                return;
            }

            BackgroundAudioTaskStartedMessage backgroundAudioTaskStartedMessage;
            if (MessageService.TryParseMessage(e.Data, out backgroundAudioTaskStartedMessage))
            {
                backgroundAudioTaskStarted.Set();
                return;
            }

            UVCButtonPressedMessage uvcButtonPressedMessage;
            if (MessageService.TryParseMessage(e.Data, out uvcButtonPressedMessage))
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    switch (uvcButtonPressedMessage.Button)
                    {
                        case SystemMediaTransportControlsButton.Play:
                            PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Pause.png"));
                            break;
                        case SystemMediaTransportControlsButton.Pause:
                            PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Play.png"));
                            break;
                    }
                });
                return;
            }
        }

        public int GetSongIndexById(Uri id)
        {
            return App.likes.FindIndex(s => new Uri(s.stream_url) == id);
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            if (isMyBackgroundTaskRunning)
            {
                ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.BackgroundTaskState, BackgroundTaskState.Running.ToString());
            }
            return base.OnNavigatedFromAsync(pageState, suspending);
        }

        private Uri GetCurrentTrackId()
        {
            object value = ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.TrackId);
            if (value != null)
                return new Uri((String)value);
            else
                return null;
        }


        private async void LoadTrack(SoundCloudTrack currentTrack)
        {
            try
            {
                string albumartImage = "";
                //Change album art
                if (currentTrack.artwork_url != null)
                {
                    albumartImage = Convert.ToString(currentTrack.artwork_url);
                }
                if (string.IsNullOrWhiteSpace(albumartImage))
                {
                    albumartImage = @"ms-appx:///Assets/Albumart.jpg";

                }
                else
                {
                    albumartImage = albumartImage.Replace("-large", "-t500x500");
                }

                AlbumImage = new BitmapImage(new Uri(albumartImage));

                //Change Title and User name
                SongName = currentTrack.title;
                AlbumTitle = Convert.ToString(currentTrack.user.username);

            }
            catch (Exception ex)
            {
                MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                await showMessgae.ShowAsync();
            }
        }

        public void PlayButtonClicked()
        {
            if (IsMyBackgroundTaskRunning)
            {
                if (MediaPlayerState.Playing == BackgroundMediaPlayer.Current.CurrentState)
                {
                    BackgroundMediaPlayer.Current.Pause();
                    PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Play.png"));
                }
                else if (MediaPlayerState.Paused == BackgroundMediaPlayer.Current.CurrentState)
                {
                    BackgroundMediaPlayer.Current.Play();
                    PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Pause.png"));
                }
                else if (MediaPlayerState.Closed == BackgroundMediaPlayer.Current.CurrentState)
                {
                    StartBackgroundAudioTask();
                }
            }
            else
            {
                StartBackgroundAudioTask();
            }
        }

        public void NextButtonClicked()
        {
            //Send message to background task
            MessageService.SendMessageToBackground(new SkipNextMessage());

        }

        public void PreviousButtonClicked()
        {
            //Send message to background task
            MessageService.SendMessageToBackground(new SkipPreviousMessage());
        }

    }
}