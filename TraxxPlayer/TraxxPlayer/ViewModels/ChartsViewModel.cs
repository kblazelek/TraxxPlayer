using BackgroundAudioShared;
using BackgroundAudioShared.Enums_and_constants;
using BackgroundAudioShared.Helpers;
using BackgroundAudioShared.Messages;
using BackgroundAudioShared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    class ChartsViewModel : CommonViewModel
    {
        Dictionary<string, string> GenresDictionary;
        Dictionary<string, string> KindsDictionary;
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public ObservableCollection<string> Genres { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Kinds { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<PlaylistToDisplay> Playlists { get; set; } = new ObservableCollection<PlaylistToDisplay>();
        DelegateCommand<PlaylistToDisplay> addTrackToPlaylistCommand;
        public DelegateCommand<PlaylistToDisplay> AddTrackToPlaylistCommand => addTrackToPlaylistCommand ?? (addTrackToPlaylistCommand = new DelegateCommand<PlaylistToDisplay>(AddTrackToPlaylist));
        DelegateCommand<SoundCloudTrack> soundCloudTrackRightTappedCommand;
        public DelegateCommand<SoundCloudTrack> SoundCloudTrackRightTappedCommand => soundCloudTrackRightTappedCommand ?? (soundCloudTrackRightTappedCommand = new DelegateCommand<SoundCloudTrack>(TrackRightTapped));
        SoundCloudTrack rightTappedTrack = null;
        private string _selectedGenre;

        public string SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                GetTracks();
                OnPropertyChanged(nameof(SelectedGenre));
            }
        }

        private string _selectedKind;

        public string SelectedKind
        {
            get { return _selectedKind; }
            set
            {
                _selectedKind = value;
                GetTracks();
                OnPropertyChanged(nameof(SelectedKind));
            }
        }

        public void ItemClicked(object sender, ItemClickEventArgs e)
        {
            App.PlaylistManager.PlayTrack(e.ClickedItem as SoundCloudTrack);
        }

        public void AddTrackToPlaylist(PlaylistToDisplay playlistSelected)
        {
            if (rightTappedTrack != null && playlistSelected != null)
            {
                PlaylistTrackService.AddPlaylistTrack(new PlaylistTrackToAdd() { PlaylistID = playlistSelected.id, TrackID = rightTappedTrack.id });
            }
        }

        public void TrackRightTapped(SoundCloudTrack track)
        {
            rightTappedTrack = track;
        }

        public async Task GetTracks()
        {
            if (!String.IsNullOrEmpty(SelectedGenre) && !String.IsNullOrEmpty(SelectedKind))
            {
                try
                {
                    string responseText = await JsonHelper.GetjsonStream(@"https://api-v2.soundcloud.com/" + "charts?kind=" + KindsDictionary.FirstOrDefault(x => x.Value == SelectedKind).Key + "&genre=soundcloud%3Agenres%3A" + GenresDictionary.FirstOrDefault(x => x.Value == SelectedGenre).Key + "&client_id=" + SoundCloudConstants.SoundCloudClientId + "&limit=50&linked_partitioning=1");
                    SoundCloudChart chart = JsonConvert.DeserializeObject<SoundCloudChart>(responseText);
                    Tracks.Clear();
                    var tempTracks = chart.collection.Select(ts => ts.track);
                    foreach (var track in tempTracks)
                    {
                        Tracks.Add(track);
                    }
                }
                catch (Exception ex)
                {
                    MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                    await showMessgae.ShowAsync();
                }
            }
        }


        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            try
            {
                GenresDictionary = await SoundCloudHelper.GetGenres();
                KindsDictionary = await SoundCloudHelper.GetKinds();
                foreach (var g in GenresDictionary)
                {
                    Genres.Add(g.Value);
                }
                foreach (var k in KindsDictionary)
                {
                    Kinds.Add(k.Value);
                }
                foreach (var p in PlaylistService.GetPlaylists(App.SCUser.id))
                {
                    Playlists.Add(p);
                }
                SelectedGenre = Genres.FirstOrDefault();
                SelectedKind = Kinds.FirstOrDefault();
                await base.OnNavigatedToAsync(parameter, mode, state);

            }
            catch (Exception ex)
            {
                MessageDialog showMessgae = new MessageDialog("Something went wrong. Please try again. Error Details : " + ex.Message);
                await showMessgae.ShowAsync();
            }
        }
    }
}
