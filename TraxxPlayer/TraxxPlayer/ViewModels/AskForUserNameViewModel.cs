using BackgroundAudioShared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

namespace TraxxPlayer.ViewModels
{
    public class AskForUserNameViewModel : CommonViewModel
    {
        private string _scUserName;

        public string SCUserName
        {
            get { return _scUserName; }
            set { _scUserName = value; OnPropertyChanged(nameof(SCUserName)); }
        }

        private bool _isUserNameFocused;

        public bool IsUserNameFocused
        {
            get { return _isUserNameFocused; }
            set { _isUserNameFocused = value; OnPropertyChanged(nameof(SCUserName)); }
        }

        public AskForUserNameViewModel()
        {
            IsUserNameFocused = true;
        }


        public void TextBoxUserName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) AddSoundCloudUser();
        }
        public async void AddSoundCloudUser()
        {
            App.SoundCloudUserName = SCUserName;
            await App.GetUserDetails();
            if (App.SCUserID == 0)
            {
                MessageDialog showMessgae = new MessageDialog("User not found");
                await showMessgae.ShowAsync();
            }
            else
            {
                await App.GetLikes();
                ApplicationSettingsHelper.SaveSettingsValue(ApplicationSettingsConstants.SCUserName, App.SoundCloudUserName);
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
        }
    }
}
