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
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Models;
using Template10.Common;
using TraxxPlayer.UI.Views;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace TraxxPlayer.UI
{
    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        #region Private members
        static PlaylistManager playlistManager = new PlaylistManager();
        private static UserToDisplay user;
        #endregion

        public static PlaylistManager PlaylistManager
        {
            get { return playlistManager; }
            set { playlistManager = value; }
        }
        public static UserToDisplay User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                Logger.User = user;
            }
        }
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 400, Height = 600 });
            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame 
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                var Shell = new Views.Shell(nav);
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
            UserToDisplay defaultUser = null;
            try
            {
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
                Logger.LogError(this, ex.Message);
                WindowWrapper.Current().Dispatcher.Dispatch(() =>
                {
                    var errorMessage = "There was an error during fetching default user.";
                    var modal = Window.Current.Content as ModalDialog;
                    var errorDialog = new ErrorDialog(errorMessage);
                    modal.ModalContent = errorDialog;
                    modal.IsModal = true;
                    modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
                });
            }
        }
    }
}

