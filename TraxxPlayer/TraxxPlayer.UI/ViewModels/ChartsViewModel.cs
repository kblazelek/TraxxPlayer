using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Models;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.UI.ViewModels
{
    class ChartsViewModel : CommonSoundCloudTrackViewModel
    {
        Dictionary<string, string> GenresDictionary;
        Dictionary<string, string> KindsDictionary;
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public ObservableCollection<string> Genres { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Kinds { get; set; } = new ObservableCollection<string>();   
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

        public async Task GetTracks()
        {
            if (!String.IsNullOrEmpty(SelectedGenre) && !String.IsNullOrEmpty(SelectedKind))
            {
                try
                {
                    Tracks.Clear();
                    var tempTracks = await SoundCloudHelper.GetTracksByKindAndGenre(KindsDictionary.FirstOrDefault(x => x.Value == SelectedKind).Key, GenresDictionary.FirstOrDefault(x => x.Value == SelectedGenre).Key);
                    foreach (var track in tempTracks)
                    {
                        Tracks.Add(track);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(this, App.User, ex.Message);
                    ShowErrorMessage("There was and error during fetching tracks from SoundCloud.");
                }
            }
        }


        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            try
            {
                // Fill Genres and Kinds dictionaries
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
                // Select first Genre and Kind
                SelectedGenre = Genres.FirstOrDefault();
                SelectedKind = Kinds.FirstOrDefault();
                await base.OnNavigatedToAsync(parameter, mode, state);
            }
            catch (Exception ex)
            {
                Logger.LogError(this, App.User, ex.Message);
                ShowErrorMessage("There was and error during fetching tracks from SoundCloud.");
            }
        }
    }
}
