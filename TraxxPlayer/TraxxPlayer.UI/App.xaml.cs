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
        public static UserToAddAndDisplay User { get; set; }
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
            UserToAddAndDisplay defaultUser = null;
            try
            {
                 UserService.MigrateDatabase();
                // Get default user from db
                defaultUser = UserService.GetDefaultUser();
                if (defaultUser != null)
                {
                    User = defaultUser;
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

