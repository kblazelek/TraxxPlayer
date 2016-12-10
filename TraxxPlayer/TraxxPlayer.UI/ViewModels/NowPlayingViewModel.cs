using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using TraxxPlayer.Common.Enums_and_constants;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Messages;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
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
        private ImageSource _albumImage;
        private ImageSource _playPauseImage;
        private string _songName;
        private string _albumTitle;
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
        private bool mediaButtonsEnabled = false;

        public bool MediaButtonsEnabled
        {
            get { return mediaButtonsEnabled; }
            set { mediaButtonsEnabled = value; OnPropertyChanged(nameof(MediaButtonsEnabled)); }
        }

        public NowPlayingViewModel()
        {
            AlbumImage = new BitmapImage(new Uri(@"ms-appx:///Assets/Albumart.png"));
        }

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
        private async void PlayLikes()
        {
            var likesTrackIDs = LikeService.GetLikes(App.User.id).Select(l => l.TrackID).ToList();
            if (likesTrackIDs.Count > 0)
            {
                List<SoundCloudTrack> likedTracks = new List<SoundCloudTrack>();
                foreach (var trackID in likesTrackIDs)
                {
                    var track = await SoundCloudHelper.GetSoundCloudTrack(trackID);
                    likedTracks.Add(track);
                }
                App.PlaylistManager.PlayTracks(likedTracks);
            }
        }
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            AlbumImage = new BitmapImage(new Uri(@"ms-appx:///Assets/Albumart.jpeg"));
            MediaButtonsEnabled = false;
            AddMediaPlayerEventHandlers();
            backgroundAudioTaskStarted = new AutoResetEvent(false);

            if (!IsMyBackgroundTaskRunning)
            {
                PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Play.png"));
                StartBackgroundAudioTask();
                PlayLikes();
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
            // Dodac sprawdzanie czy jaest jakas muzyka do grania
            PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Pause.png"));
            var trackId = GetCurrentTrackId();
            if (trackId != null)
            {
                //TODO: Dodać obsługę playlisty zamiast likes
                //var song = App.likes.Where(t => t.stream_url == trackId.ToString()).FirstOrDefault();

                var song = App.PlaylistManager.Tracks.Where(t => t.stream_url == trackId.ToString()).FirstOrDefault();
                if (song != null)
                {
                    LoadTrack(song);
                    MediaButtonsEnabled = true;
                }
            }
            return base.OnNavigatedToAsync(parameter, mode, state);

        }

        private void StartBackgroundAudioTask()
        {
            var startResult = CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                bool result = backgroundAudioTaskStarted.WaitOne(10000);
                //Send message to initiate playback
                if (result == true)
                {
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
            BackgroundMediaPlayer.MessageReceivedFromBackground += BackgroundMediaPlayer_MessageReceivedFromBackground;
        }
        private void RemoveMediaPlayerEventHandlers()
        {
            BackgroundMediaPlayer.MessageReceivedFromBackground -= BackgroundMediaPlayer_MessageReceivedFromBackground;
        }

        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            RemoveMediaPlayerEventHandlers();
            return base.OnNavigatingFromAsync(args);
        }

        async void BackgroundMediaPlayer_MessageReceivedFromBackground(object sender, MediaPlayerDataReceivedEventArgs e)
        {
            TrackChangedMessage trackChangedMessage;
            if (MessageService.TryParseMessage(e.Data, out trackChangedMessage))
            {
                Debug.WriteLine("NowPlayingViewModel.BackgroundMediaPlayer_MessageReceivedFromBackground: Received TrackChangedMessage from Background");
                // Enable media buttons
                if (BackgroundMediaPlayer.Current.CurrentState == MediaPlayerState.Playing)
                {
                    await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        MediaButtonsEnabled = true;
                    });
                }
                // When foreground app is active change track based on background message
                await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var track = GetTrackFromStreamURL(trackChangedMessage.TrackId.ToString());
                    if (track != null)
                    {
                        LoadTrack(track); //Update UI
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

            PlaybackListEmptyMessage playbackListEmptyMessage;
            if (MessageService.TryParseMessage(e.Data, out playbackListEmptyMessage))
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Debug.WriteLine("NowPlayingViewModel.BackgroundMediaPlayer_MessageReceivedFromBackground: Received PlaybackListEmptyMessage from Background");
                    AlbumImage = new BitmapImage(new Uri(@"ms-appx:///Assets/Albumart.jpeg"));
                    PlayPauseImage = new BitmapImage(new Uri("ms-appx:///Assets/Play.png"));
                    MediaButtonsEnabled = false;
                    SongName = "";
                    AlbumTitle = "";
                });
                return;
            }
        }

        public SoundCloudTrack GetTrackFromStreamURL(string streamURL)
        {
            // Dodac sprawdzanie, gdy stream_url jest pusty, ale mozna go uzyskac z innych pól
            return App.PlaylistManager.Tracks.Where(t => t.stream_url == streamURL).FirstOrDefault();
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
