using BackgroundAudioShared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using TraxxPlayer.Services;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    public class ShellViewModel : CommonViewModel
    {
        DelegateCommand<SoundCloudTrack> deleteTrackFromPlaylistCommand;
        public DelegateCommand<SoundCloudTrack> DeleteTrackFromPlaylistCommand => deleteTrackFromPlaylistCommand ?? (deleteTrackFromPlaylistCommand = new DelegateCommand<SoundCloudTrack>(DeleteTrackFromPlaylist));
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = App.PlaylistManager.Tracks;

        private SoundCloudTrack selectedTrack;
        public SoundCloudTrack SelectedTrack
        {
            get
            {
                return selectedTrack;
            }
            set
            {
                selectedTrack = value;
                OnPropertyChanged(nameof(SelectedTrack));
                App.PlaylistManager.PlayPlaylistTrack(selectedTrack);
            }
        }
        private async void DeleteTrackFromPlaylist(SoundCloudTrack track)
        {
            try
            {
                if (App.PlaylistManager.Playlist != null)
                {
                    // TODO: Dodać zamianę kolejności
                    Debug.WriteLine($"Deleting track {track.id} from playlist {App.PlaylistManager.Playlist.id}");
                    PlaylistTrackService.DeletePlaylistTrack(App.PlaylistManager.Playlist.id, track.id);
                    // Poprawić, żeby przy usuwaniu nie odtwarzał na nowo
                    //await App.PlaylistManager.PlayPlaylist(App.PlaylistManager.Playlist);
                    App.PlaylistManager.RemoveTrackFromCurrentPlaylist(track);
                }
            }
            catch (Exception ex)
            {
                ShowWarningMessage(ex.Message);
            }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            return base.OnNavigatedToAsync(parameter, mode, state);
        }


    }
}
