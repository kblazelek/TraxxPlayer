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
    public class MainPageViewModel : CommonViewModel
    {
        public ObservableCollection<SoundCloudTrack> RecentlyPopularTracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public MainPageViewModel()
        {
            //var recentlyPopularTracks = TrackHistoryService.GetTracksHistory(App.User.id, 500).GroupBy(th => th.TrackID).Select(g => g.Count()).OrderByDescending();

        }


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var recentlyPopularTracks =
            (from th in TrackHistoryService.GetTracksHistory(App.User.id, 500)
             group th by th.TrackID into g
             select new { TrackID = g.Key, TrackCount = g.Count() }).Take(5);
            foreach (var track in recentlyPopularTracks)
            {
                var t = await SoundCloudHelper.GetSoundCloudTrack(track.TrackID);
                RecentlyPopularTracks.Add(t);
            }
            await Task.CompletedTask;
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

