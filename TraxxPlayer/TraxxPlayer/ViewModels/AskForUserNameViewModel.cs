using BackgroundAudioShared;
using BackgroundAudioShared.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

namespace TraxxPlayer.ViewModels
{
    public class AskForUserNameViewModel : CommonViewModel
    {
        private string _scUserName;
        private ObservableCollection<string> previousUsers { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> PreviousUsersQuery { get; set; } = new ObservableCollection<string>();

        public string SCUserName
        {
            get { return _scUserName; }
            set
            {
                _scUserName = value;
                if (_scUserName.Length > 0)
                {
                    PreviousUsersQuery.Clear();
                    foreach (var user in previousUsers.Where(u => u.ToLower().Contains(_scUserName.ToLower())))
                    {
                        PreviousUsersQuery.Add(user);
                    }
                }
                OnPropertyChanged(nameof(SCUserName));
            }
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
            foreach (var p in UserService.GetUsers().Select(user => user.permalink))
            {
                previousUsers.Add(p);
            }
        }


        public void TextBoxUserName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) AddSoundCloudUser();
        }
        public async void AddSoundCloudUser()
        {
            App.SCUser = await SoundCloudHelper.GetUserDetails(SCUserName);
            if (App.SCUser == null)
            {
                MessageDialog showMessgae = new MessageDialog("User not found");
                await showMessgae.ShowAsync();
            }
            else
            {
                if (!UserService.UserExist(App.SCUser.id))
                {
                    UserService.AddUser(new UserToAddAndDisplay(App.SCUser));
                }
                else
                {
                    var userFromDB = UserService.GetUser(App.SCUser.id);
                    if (!userFromDB.Equals(App.SCUser))
                    {
                        UserService.ModifyUser(new UserToAddAndDisplay(App.SCUser));
                    }
                }
                await App.GetLikes();
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
        }
    }
}
