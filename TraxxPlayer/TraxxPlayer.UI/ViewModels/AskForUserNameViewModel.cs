using BackgroundAudioShared.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

namespace TraxxPlayer.UI.ViewModels
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
                    UserService.AddUser(new UserToAddAndDisplay()
                    {
                        id = App.SCUser.id,
                        avatar_url = App.SCUser.avatar_url,
                        city = (string)App.SCUser.city,
                        country = (string)App.SCUser.country,
                        description = (string)App.SCUser.description,
                        discogs_name = (string)App.SCUser.discogs_name,
                        first_name = App.SCUser.first_name,
                        followers_count = App.SCUser.followers_count,
                        followings_count = App.SCUser.followings_count,
                        full_name = App.SCUser.full_name,
                        kind = App.SCUser.kind,
                        last_modified = App.SCUser.last_modified,
                        last_name = App.SCUser.last_name,
                        myspace_name = (string)App.SCUser.myspace_name,
                        online = App.SCUser.online,
                        permalink = App.SCUser.permalink,
                        permalink_url = App.SCUser.permalink_url,
                        plan = App.SCUser.plan,
                        playlist_count = App.SCUser.playlist_count,
                        public_favorites_count = App.SCUser.public_favorites_count,
                        track_count = App.SCUser.track_count,
                        uri = App.SCUser.uri,
                        username = App.SCUser.username,
                        website = (string)App.SCUser.website,
                        website_title = (string)App.SCUser.website_title
                    });
                }
                else
                {
                    var userFromDB = UserService.GetUser(App.SCUser.id);
                    if (!userFromDB.Equals(App.SCUser))
                    {
                        UserService.ModifyUser((new UserToAddAndDisplay()
                        {
                            id = App.SCUser.id,
                            avatar_url = App.SCUser.avatar_url,
                            city = (string)App.SCUser.city,
                            country = (string)App.SCUser.country,
                            description = (string)App.SCUser.description,
                            discogs_name = (string)App.SCUser.discogs_name,
                            first_name = App.SCUser.first_name,
                            followers_count = App.SCUser.followers_count,
                            followings_count = App.SCUser.followings_count,
                            full_name = App.SCUser.full_name,
                            kind = App.SCUser.kind,
                            last_modified = App.SCUser.last_modified,
                            last_name = App.SCUser.last_name,
                            myspace_name = (string)App.SCUser.myspace_name,
                            online = App.SCUser.online,
                            permalink = App.SCUser.permalink,
                            permalink_url = App.SCUser.permalink_url,
                            plan = App.SCUser.plan,
                            playlist_count = App.SCUser.playlist_count,
                            public_favorites_count = App.SCUser.public_favorites_count,
                            track_count = App.SCUser.track_count,
                            uri = App.SCUser.uri,
                            username = App.SCUser.username,
                            website = (string)App.SCUser.website,
                            website_title = (string)App.SCUser.website_title
                        }));
                    }
                }
                await App.GetLikes();
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
        }
    }
}
