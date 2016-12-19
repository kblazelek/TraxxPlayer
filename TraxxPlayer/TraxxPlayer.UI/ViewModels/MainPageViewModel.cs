using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.UI.ViewModels
{
    public class MainPageViewModel : CommonSoundCloudTrackViewModel
    {
        public ObservableCollection<SoundCloudTrack> RecentlyPopularTracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public string HelloUserText { get; set; }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            try
            {
                HelloUserText = $"Hello, {App.User.username}";
                var recentlyPopularTracks =
                (from th in TrackHistoryService.GetTracksHistory(App.User.id, 250)
                 group th by th.TrackID into g
                 select new { TrackID = g.Key, TrackCount = g.Count() }).Take(5);
                foreach (var track in recentlyPopularTracks)
                {
                    var t = await SoundCloudHelper.GetSoundCloudTrack(track.TrackID);
                    RecentlyPopularTracks.Add(t);
                }
                await Task.CompletedTask;
            }
            catch(Exception ex)
            {
                Logger.LogError(this, App.User, ex.Message);
                ShowErrorMessage("There was an error during fetching your recently popular tracks.");
            }
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            await Task.CompletedTask;
        }

    }
}

