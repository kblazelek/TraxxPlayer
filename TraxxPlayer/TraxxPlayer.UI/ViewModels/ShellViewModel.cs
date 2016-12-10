using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.UI.ViewModels
{
    public class ShellViewModel : CommonViewModel
    {
        DelegateCommand<SoundCloudTrack> deleteTrackFromPlaylistCommand;
        public DelegateCommand<SoundCloudTrack> DeleteTrackFromPlaylistCommand => deleteTrackFromPlaylistCommand ?? (deleteTrackFromPlaylistCommand = new DelegateCommand<SoundCloudTrack>(DeleteTrackFromPlaylist));
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = App.PlaylistManager.Tracks;
        private SoundCloudTrack lastRemovedTrack;
        private int lastRemovedTrackIndex;

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
        private void DeleteTrackFromPlaylist(SoundCloudTrack track)
        {
            try
            {
                if (App.PlaylistManager.Playlist != null)
                {
                    // TODO: Dodać zamianę kolejności
                    Debug.WriteLine($"ShellViewModel.DeleteTrackFromPlaylist: Deleting track {track.id} from playlist {App.PlaylistManager.Playlist.id}");
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

        public ShellViewModel()
        {
            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            Tracks.CollectionChanged += Tracks_CollectionChanged;
        }



        private void Tracks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    lastRemovedTrack = (SoundCloudTrack)e.OldItems[0];
                    lastRemovedTrackIndex = e.OldStartingIndex;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if(lastRemovedTrack == null)
                    {
                        return;
                    }
                    var newIndex = e.NewStartingIndex;
                    if (App.PlaylistManager.Playlist != null)
                    {
                        App.PlaylistManager.ReorderTracks(lastRemovedTrack, lastRemovedTrackIndex, newIndex);
                    }
                    lastRemovedTrack = null;
                    lastRemovedTrackIndex = -1;
                    break;
            }
        }
    }
}
