using BackgroundAudioShared;
using BackgroundAudioShared.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    class ChartsViewModel : CommonViewModel
    {
        Dictionary<string, string> GenresDictionary;
        Dictionary<string, string> KindsDictionary;
        ObservableCollection<SoundCloudTrack> Tracks { get; set; }
        public ObservableCollection<string> Genres { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Kinds { get; set; } = new ObservableCollection<string>();
        private string _selectedGenre;

        public string SelectedGenre
        {
            get { return _selectedGenre; }
            set
            { _selectedGenre = value; OnPropertyChanged(nameof(SelectedGenre)); }
        }

        private string _selectedKind;

        public string SelectedKind
        {
            get { return _selectedKind; }
            set { _selectedKind = value; OnPropertyChanged(nameof(SelectedKind)); }
        }


        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
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
            SelectedGenre = Genres.FirstOrDefault();
            SelectedKind = Kinds.FirstOrDefault();
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
