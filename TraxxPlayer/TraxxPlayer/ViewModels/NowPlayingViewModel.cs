using BackgroundAudioShared;
using BackgroundAudioShared.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.ApplicationModel.Core;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    public class NowPlayingViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool isMyBackgroundTaskRunning = false;
        //AppShell shell = Window.Current.Content as AppShell;
        private AutoResetEvent backgroundAudioTaskStarted;
        private ImageSource _albumImage;
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
        new public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                StartBackgroundAudioTask();
            }
            else
            {
                //Start playback if Paused.
                if (MediaPlayerState.Paused == BackgroundMediaPlayer.Current.CurrentState)
                {
                    BackgroundMediaPlayer.Current.Play();
                }
                else if (MediaPlayerState.Closed == BackgroundMediaPlayer.Current.CurrentState)
                {
                    StartBackgroundAudioTask();
                }
            }
            var trackId = GetCurrentTrackId();
            if (trackId != null)
            {
                var song = App.likes.Where(t => t.stream_url == trackId.ToString()).FirstOrDefault();
                LoadTrack(song);
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
                //Change album art
                string albumartImage = Convert.ToString(currentTrack.artwork_url);
                if (string.IsNullOrWhiteSpace(albumartImage))
                {
                    albumartImage = @"ms-appx:///Assets/Albumart.png";

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
                }
                else if (MediaPlayerState.Paused == BackgroundMediaPlayer.Current.CurrentState)
                {
                    BackgroundMediaPlayer.Current.Play();
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
