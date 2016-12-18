using System;
using System.Collections.ObjectModel;
using System.Linq;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;

namespace TraxxPlayer.UI.ViewModels
{
    public class AskForUserNameViewModel : CommonViewModel
    {
        private string _userName;
        private bool? isDefault;
        private ObservableCollection<string> previousUsers { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> PreviousUsersQuery { get; set; } = new ObservableCollection<string>();
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

        public void AddUserOrLogIn()
        {
            try
            {
                UserToDisplay tempUser = null;
                if (!UserService.UserExist(UserName)) // If new user
                {
                    UserService.AddUser(new UserToAdd()
                    {
                        username = UserName,
                        isDefault = (bool)IsDefault
                    });
                    tempUser = UserService.GetUser(UserName);
                    Logger.LogInfo(this, App.User, $"Added user {App.User.username} (ID: {App.User.id})");
                    App.User = tempUser;
                    Logger.LogInfo(this, App.User, $"Logged in as user {App.User.username} (ID: {App.User.id})");

                }
                else // If user exists
                {
                    tempUser = UserService.GetUser(UserName);
                    if (tempUser.isDefault != IsDefault)
                    {
                        tempUser.isDefault = (bool)IsDefault;
                        UserService.ModifyUser(tempUser);
                        Logger.LogInfo(this, App.User, $"Modified user {App.User.username} (ID: {App.User.id})");
                    }
                    App.User = tempUser;
                    Logger.LogInfo(this, App.User, $"Logged in as user {App.User.username} (ID: {App.User.id})");
                }
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
            catch(Exception ex)
            {
                Logger.LogError(this, App.User, ex.Message);
                ShowErrorMessage("There was and error during loggin in / adding user.");
            }
        }
    }
}
