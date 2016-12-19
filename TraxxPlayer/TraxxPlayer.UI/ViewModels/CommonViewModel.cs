using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Template10.Common;
using Template10.Controls;
using Template10.Mvvm;
using TraxxPlayer.Common.Enums_and_constants;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using TraxxPlayer.UI.Views;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TraxxPlayer.UI.ViewModels
{
    public class CommonViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public static AutoResetEvent backgroundAudioTaskStarted;
        public static bool isMyBackgroundTaskRunning = false;
        new public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowErrorMessage(string errorMessage)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                var errorDialog = new ErrorDialog(errorMessage);
                modal.ModalContent = errorDialog;
                modal.IsModal = true;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }

        public void ShowWarningMessage(string warningMessage)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                var warningDialog = new WarningDialog(warningMessage);
                modal.ModalContent = warningDialog;
                modal.IsModal = true;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }

        protected bool IsMyBackgroundTaskRunning
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

        protected async void PlayLikes()
        {
            try
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
            catch(Exception ex)
            {
                Logger.LogError(this, App.User, ex.Message);
                ShowErrorMessage("There was an error during playing liked tracks.");
            }
        }

        protected void StartBackgroundAudioTask()
        {
            try
            {
                var startResult = CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    bool result = backgroundAudioTaskStarted.WaitOne(10000);
                //Send message to initiate playback
                if (result == false)
                    {
                        throw new Exception("Background Audio Task didn't start in expected time");
                    }
                });
            }
            catch(Exception ex)
            {
                Logger.LogError(this, App.User, ex.Message);
                ShowErrorMessage("There was an error during starting background audio player.");
            }
        }
    }
}
