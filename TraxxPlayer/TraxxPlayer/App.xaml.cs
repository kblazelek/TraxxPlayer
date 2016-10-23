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

namespace TraxxPlayer
{
    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    { 
        public static string SoundCloudUserName = "";
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

        public static async Task GetUserDetails()
        {
            try
            {
                string responseText = await JsonHelper.GetjsonStream(SoundCloudConstants.SoundCloudAPILink + SoundCloudConstants.SoundCloudAPIUsers + SoundCloudUserName + ".json?client_id=" + SoundCloudConstants.SoundCloudClientId);
                SoundCloudUser tempUser = JsonConvert.DeserializeObject<SoundCloudUser>(responseText);
                if (tempUser.id != 0)
                {
                    SCUser = tempUser;
                }
            }
            catch (Exception ex)
            {
                MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                await showMessgae.ShowAsync();
            }
        }

        public static async Task GetLikes()
        {
            try
            {
                likes = await SoundCloudHelper.GetLikedTracks(SCUser.id);
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

                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Views.Shell(nav),
                    ModalContent = new Views.Busy(),
                };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here
            //ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.SCUserName);
            SoundCloudUserName =  ApplicationSettingsHelper.ReadSettingsValue(ApplicationSettingsConstants.SCUserName) as string;
            await GetUserDetails();
            if (SCUser != null)
            {
                await GetLikes();
                NavigationService.Navigate(typeof(Views.NowPlaying));
            }
            else
            {
                NavigationService.Navigate(typeof(Views.AskForUserName));
            } 
            await Task.CompletedTask;
        }
    }
}

