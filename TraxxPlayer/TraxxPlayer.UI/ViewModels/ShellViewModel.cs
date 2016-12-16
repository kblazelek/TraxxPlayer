using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using TraxxPlayer.Common.Enums_and_constants;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Messages;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.Media.Playback;
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
                    Debug.WriteLine($"ShellViewModel.DeleteTrackFromPlaylist: Deleting track {track.id} from playlist {App.PlaylistManager.Playlist.id}");
                    PlaylistTrackService.DeletePlaylistTrack(App.PlaylistManager.Playlist.id, track.id);
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
            Tracks.CollectionChanged += Tracks_CollectionChanged;
            BackgroundMediaPlayer.MessageReceivedFromBackground += BackgroundMediaPlayer_MessageReceivedFromBackground;
            if (!IsMyBackgroundTaskRunning)
            {
                backgroundAudioTaskStarted = new AutoResetEvent(false);
                StartBackgroundAudioTask();
            }
        }

        private void Tracks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    // When track was really removed (not only being reordered) then don't store it's value.
                    if (App.PlaylistManager.Tracks.Contains((SoundCloudTrack)e.OldItems[0]))
                    {
                        lastRemovedTrack = (SoundCloudTrack)e.OldItems[0];
                        lastRemovedTrackIndex = e.OldStartingIndex;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (lastRemovedTrack == null)
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
        public SoundCloudTrack GetTrackFromStreamURL(string streamURL)
        {
            return Tracks.Where(t => t.stream_url == streamURL).FirstOrDefault();
        }
        void BackgroundMediaPlayer_MessageReceivedFromBackground(object sender, MediaPlayerDataReceivedEventArgs e)
        {
            TrackChangedMessage trackChangedMessage;
            if (MessageService.TryParseMessage(e.Data, out trackChangedMessage))
            {
                Logger.LogInfo(this, App.User, "Received TrackChangedMessage from Background");
                Debug.WriteLine("ShellViewModel.BackgroundMediaPlayer_MessageReceivedFromBackground: Received TrackChangedMessage from Background");
                var track = GetTrackFromStreamURL(trackChangedMessage.TrackId.ToString());
                if (track != null)
                {
                    TrackHistoryService.AddTrackHistory(new TrackHistoryToAdd() { UserID = App.User.id, TrackID = track.id });
                }
            }

            BackgroundAudioTaskStartedMessage backgroundAudioTaskStartedMessage;
            if (MessageService.TryParseMessage(e.Data, out backgroundAudioTaskStartedMessage))
            {
                backgroundAudioTaskStarted.Set();
                return;
            }

            PlaybackListEmptyMessage playbackListEmptyMessage;
            if (MessageService.TryParseMessage(e.Data, out playbackListEmptyMessage))
            {
                App.PlaylistManager.StopPlayer();
                return;
            }
        }
    }
}
