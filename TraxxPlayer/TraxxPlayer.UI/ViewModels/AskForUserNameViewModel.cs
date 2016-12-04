using System;
using System.Collections.ObjectModel;
using System.Linq;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

namespace TraxxPlayer.UI.ViewModels
{
    public class AskForUserNameViewModel : CommonViewModel
    {
        private string _userName;
        private ObservableCollection<string> previousUsers { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> PreviousUsersQuery { get; set; } = new ObservableCollection<string>();
        private bool? isDefault;

        public bool? IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; OnPropertyChanged(nameof(IsDefault)); }
        }


        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                if (_userName.Length > 0)
                {
                    PreviousUsersQuery.Clear();
                    foreach (var user in previousUsers.Where(u => u.ToLower().Contains(_userName.ToLower())))
                    {
                        PreviousUsersQuery.Add(user);
                    }
                }
                OnPropertyChanged(nameof(UserName));
            }
        }

        public AskForUserNameViewModel()
        {
            IsDefault = false;
            foreach (var p in UserService.GetUsers().Select(user => user.username))
            {
                previousUsers.Add(p);
            }
        }

        public void AddUser()
        {
            UserToAddAndDisplay tempUser = null;
            if (!UserService.UserExist(UserName))
            {
                if (IsDefault == true)
                {
                    var defaultUser = UserService.GetDefaultUser();
                    if (defaultUser != null)
                    {
                        UserService.RemoveDefaultUser(defaultUser.id);
                    }
                    tempUser = new UserToAddAndDisplay()
                    {
                        username = UserName,
                        isDefault = true
                    };
                }
                else
                {
                    tempUser = new UserToAddAndDisplay()
                    {
                        username = UserName,
                        isDefault = false
                    };
                }
                UserService.AddUser(tempUser);
                App.User = tempUser;
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
            else
            {
                tempUser = UserService.GetUser(UserName);
                if (tempUser.isDefault != IsDefault)
                {
                    tempUser.isDefault = (bool)IsDefault;
                    UserService.ModifyUser(tempUser);
                }
                App.User = tempUser;
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
        }
    }
}
