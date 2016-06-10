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

namespace TraxxPlayer
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        public static string SoundCloudClientId = "9c79c1a0aeb2fc8972d215e07934a8bf";
        public static int SCUserID = 0;
        public static string SoundCloudLink = "http://api.soundcloud.com/";

        public static string SoundCloudAPIUsers = "users/";
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
                string responseText = await GetjsonStream(SoundCloudLink + SoundCloudAPIUsers + SoundCloudUserName + ".json?client_id=" + SoundCloudClientId);
                SCUser = JsonConvert.DeserializeObject<SoundCloudUser>(responseText);
                SCUserID = SCUser.id;
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
                string responseText = await GetjsonStream(SoundCloudLink + SoundCloudAPIUsers + SCUserID + "/favorites.json?client_id=" + SoundCloudClientId);
                likes = JsonConvert.DeserializeObject<List<SoundCloudTrack>>(responseText);

                //remove songs which do not have stream url
                likes = likes.Where(t => t.stream_url != null).ToList();

                //add "?client_id=" + App.SoundCloudClientId to stream url
                likes = likes.Select(t => { t.stream_url += "?client_id=" + SoundCloudClientId; return t; }).ToList();
            }
            catch (Exception ex)
            {
                MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                await showMessgae.ShowAsync();
            }

        }

        public static async Task<string> GetjsonStream(string url) //Function to read from given url
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
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
            ApplicationSettingsHelper.ReadResetSettingsValue(ApplicationSettingsConstants.SCUserName);
            SoundCloudUserName =  ApplicationSettingsHelper.ReadSettingsValue(ApplicationSettingsConstants.SCUserName) as string;
            await GetUserDetails();
            if (SCUserID != 0)
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

