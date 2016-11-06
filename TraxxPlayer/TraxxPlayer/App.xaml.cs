using Windows.UI.Xaml;
using System.Threading.Tasks;
using TraxxPlayer.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;
using BackgroundAudioShared;
using System.Collections.Generic;
using Newtonsoft.Json;
using Windows.UI.Popups;
using System.Net.Http;
using BackgroundAudioShared.Helpers;
using BackgroundAudioShared.Enums_and_constants;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;

namespace TraxxPlayer
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
                    PlaylistManager.CurrentPlaylist.Add(track);
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
                // UserService.MigrateDatabase();
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
                            UserService.ModifyUser(new UserToAddAndDisplay(SCUser));
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

