using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Messages;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using Windows.UI.Xaml.Controls;

namespace TraxxPlayer.UI.ViewModels
{
    public class SearchViewModel : CommonSoundCloudTrackViewModel
    {
        DelegateCommand<string> suggestionChosenCommand;
        public DelegateCommand<string> SuggestionChosenCommand => suggestionChosenCommand ?? (suggestionChosenCommand = new DelegateCommand<string>(SuggestionChosen));
        private delegate void SearchQueryChanged();
        private event SearchQueryChanged SearchQueryChangedEvent;
        private string textToSearch;
        public string TextToSearch
        {
            get { return textToSearch; }
            set
            {
                textToSearch = value;
                SearchQueryChangedEvent();
                OnPropertyChanged(nameof(TextToSearch));
            }
        }
        public ObservableCollection<string> SearchQuery { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public SearchViewModel()
        {
            SearchQueryChangedEvent += SearchViewModel_SearchQueryChangedEvent;
        }

        private async void SearchViewModel_SearchQueryChangedEvent()
        {
            if (textToSearch.Length > 2)
            {
                SearchQuery.Clear();
                List<SoundCloudTrack> searchResult = await SoundCloudHelper.SearchTracks(textToSearch, 50);
                foreach (var result in searchResult)
                {
                    SearchQuery.Add(result.title);
                }
            }
        }

        public async void SearchTracks()
        {
            List<SoundCloudTrack> searchResult = await SoundCloudHelper.SearchTracks(TextToSearch, 50);
            Tracks.Clear();
            foreach(var result in searchResult)
            {
                Tracks.Add(result);
            }
        }

        public void SuggestionChosen(string suggestion)
        {
            if (textToSearch != suggestion)
            {
                textToSearch = suggestion;
                OnPropertyChanged(nameof(TextToSearch));
                SearchTracks();
            }
        }
    }
}
