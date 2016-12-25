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
using TraxxPlayer.Common.Exceptions;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Messages;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
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
                var userLikes = LikeService.GetLikes(App.User.id).ToList();
                if (userLikes.Count > 0)
                {
                    List<SoundCloudTrack> likedTracks = new List<SoundCloudTrack>();
                    List<LikeToDisplay> likesToDelete = new List<LikeToDisplay>();
                    foreach (var like in userLikes)
                    {
                        var track = await SoundCloudHelper.GetSoundCloudTrack(like.TrackID);
                        if (track != null)
                        {
                            likedTracks.Add(track);
                        }
                        else
                        {
                            likesToDelete.Add(like);
                        }
                    }
                    App.PlaylistManager.PlayTracks(likedTracks);
                    if (likesToDelete.Count > 0)
                    {
                        foreach (var likeToDelete in likesToDelete)
                        {
                            LikeService.DeleteLike(likeToDelete.id);
                        }
                        throw new SoundCloudTrackNotAvailableException($"Some of your tracks were deleted from likes, because they were no longer available on SoundCloud", likesToDelete.Select(l => l.TrackID).ToList());
                    }
                }
            }
            catch(SoundCloudTrackNotAvailableException ex)
            {
                Logger.LogWarning(this, ex.Message);
                ShowWarningMessage(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError(this, ex.Message);
                ShowErrorMessage("There was an error during playing liked tracks.");
            }
        }

        protected void StartBackgroundAudioTask()
        {
            try
            {
                var qualifiers = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
                string deviceFamily = qualifiers.ContainsKey("DeviceFamily") ? qualifiers["DeviceFamily"] : String.Empty;
                var startResult = CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    bool result = backgroundAudioTaskStarted.WaitOne(10000);
                    if (result == false)
                    {
                        throw new Exception("Background Audio Task didn't start in expected time");
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(deviceFamily))
                        {
                            MessageService.SendMessageToBackground(this, new DeviceFamilyMessage(deviceFamily));
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(this, ex.Message);
                ShowErrorMessage("There was an error during starting background audio player.");
            }
        }
    }
}
