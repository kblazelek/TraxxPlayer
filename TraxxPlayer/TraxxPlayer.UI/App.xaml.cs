using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using System;
using Windows.UI.Xaml.Data;
using System.Collections.Generic;
using Windows.UI.Popups;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI.ViewManagement;
using Windows.Foundation;
using TraxxPlayer.UI.Services.SettingsServices;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Models;

namespace TraxxPlayer.UI
{
    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {

        private static PlaylistManager playlistManager = new PlaylistManager();
        public static Views.Shell Shell;

        public static PlaylistManager PlaylistManager
        {
            get { return playlistManager; }
            set { playlistManager = value; }
        }
        public static List<SoundCloudTrack> likes = new List<SoundCloudTrack>();
        public static int nowplayingTrackId = 0;
        public static SoundCloudUser SCUser { get; set; }
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region App settings
            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;
            #endregion
        }



        public static async Task GetLikes()
        {
            try
            {
                likes = await SoundCloudHelper.GetLikedTracks(SCUser.id);
                // TEST
                foreach (var track in likes)
                {
                    PlaylistManager.Tracks.Add(track);
                }
            }
            catch (Exception ex)
            {
                MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                await showMessgae.ShowAsync();
            }

        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 400, Height = 600 });
            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame 
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                Shell = new Views.Shell(nav);
                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = Shell,
                    ModalContent = new Views.Busy(),
                };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            string SoundCloudUserName = "";
            SoundCloudUser tempUser = null;
            UserToAddAndDisplay defaultUser = null;
            try
            {
                 UserService.MigrateDatabase();
                // Get default user from db
                defaultUser = UserService.GetDefaultUser();
                if (defaultUser != null)
                {
                    SoundCloudUserName = defaultUser.permalink;
                }

                // Check whether saved user still exists in SoundCloud
                if (SoundCloudUserName != "")
                {
                    tempUser = await SoundCloudHelper.GetUserDetails(SoundCloudUserName);
                }
                if (tempUser != null)
                {
                    SCUser = tempUser;
                    if (defaultUser != null)
                    {
                        // Replace user info in db if it differs from SoundCloud
                        if (!defaultUser.Equals(SCUser))
                        {
                            UserService.ModifyUser(new UserToAddAndDisplay()
                            {
                                id = SCUser.id,
                                avatar_url = SCUser.avatar_url,
                                city = (string)SCUser.city,
                                country = (string)SCUser.country,
                                description = (string)SCUser.description,
                                discogs_name = (string)SCUser.discogs_name,
                                first_name = SCUser.first_name,
                                followers_count = SCUser.followers_count,
                                followings_count = SCUser.followings_count,
                                full_name = SCUser.full_name,
                                kind = SCUser.kind,
                                last_modified = SCUser.last_modified,
                                last_name = SCUser.last_name,
                                myspace_name = (string)SCUser.myspace_name,
                                online = SCUser.online,
                                permalink = SCUser.permalink,
                                permalink_url = SCUser.permalink_url,
                                plan = SCUser.plan,
                                playlist_count = SCUser.playlist_count,
                                public_favorites_count = SCUser.public_favorites_count,
                                track_count = SCUser.track_count,
                                uri = SCUser.uri,
                                username = SCUser.username,
                                website = (string)SCUser.website,
                                website_title = (string)SCUser.website_title
                            });
                        }
                    }
                    await GetLikes();
                    NavigationService.Navigate(typeof(Views.NowPlaying));
                }
                else
                {
                    NavigationService.Navigate(typeof(Views.AskForUserName));
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                await showMessgae.ShowAsync();
            }
        }
    }
}

