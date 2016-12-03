using TraxxPlayer.Common.Enums_and_constants;
using TraxxPlayer.Common.Exceptions;
using TraxxPlayer.Common.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using TraxxPlayer.Common.Models;

namespace TraxxPlayer.Common.Helpers
{
    public class PlaylistManager : INotifyPropertyChanged
    {
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public PlaylistToDisplay Playlist { get; set; }

        public async Task PlayPlaylist(PlaylistToDisplay playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException("There was an error during fetching tracks for playlist. Play playlist failed.");
            }
            var tracks = PlaylistTrackService.GetPlaylistTracks(playlist.id).OrderBy(pt => pt.TrackOrder);
            if (tracks == null)
            {
                throw new EmptyPlaylistException("Playlist does not contain any tracks.");
            }
            else if (tracks.Count() == 0)
            {
                throw new EmptyPlaylistException("Playlist does not contain any tracks.");
            }

            Playlist = playlist;
            // Clear tracks from current playlist
            Tracks.Clear();
            foreach (var t in tracks)
            {
                var tempTrack = await SoundCloudHelper.GetSoundCloudTrack(t.TrackID);
                if (tempTrack != null)
                {
                    Tracks.Add(tempTrack);
                }
                else
                {
                    // TODO: Add custom exception containting track id to ask user whether he/she want's to delete deleted track from playlist.
                }
            }
            MessageService.SendMessageToBackground(new UpdatePlaylistMessage(Tracks.ToList()));
        }

        public void RemoveTrackFromCurrentPlaylist(SoundCloudTrack track)
        {
            if(track == null)
            {
                throw new Exception("Track to remove is null. Remove track from current playlist failed.");
            }
            if(Playlist == null)
            {
                throw new Exception("Playlist is null. Remove track from current playlist failed.");
            }
            if(!Tracks.Contains(track))
            {
                throw new Exception($"There is no track with id {track.id} in current playlist. Remove track from current playlist failed.");
            }
            // Remove later when syncing with background task
            Tracks.Remove(track);
            MessageService.SendMessageToBackground(new DeleteTrackFromPlaybackList(track));
        }

        private static string GetStreamUrlFromUri(string uri)
        {
            return uri + "/stream?client_id=" + SoundCloudConstants.SoundCloudClientId;
        }

        public void PlaySingleTrack(SoundCloudTrack track)
        {
            if (track == null)
            {
                throw new Exception("Track is empty. Play track failed.");
            }
            if (track.stream_url == null && track.uri != null)
            {
                track.stream_url = GetStreamUrlFromUri(track.uri);
            }
            if (track.stream_url != null)
            {
                MessageService.SendMessageToBackground(new UpdatePlaylistMessage(new List<SoundCloudTrack> { track }));
            }
            Tracks.Clear();
            Tracks.Add(track);
        }
        // TODO: zamienic przyjmowany parametr na id i pobierac z soundcloudhelpera
        public void PlayPlaylistTrack(SoundCloudTrack track)
        {
            if (track == null)
            {
                throw new Exception("Track is empty. Play track failed.");
            }
            if (track.stream_url == null && track.uri != null)
            {
                track.stream_url = GetStreamUrlFromUri(track.uri);
            }
            if (track.stream_url != null)
            {
                if (Tracks.Contains(track))
                {
                    MessageService.SendMessageToBackground(new TrackChangedMessage(new Uri(track.stream_url)));
                    MessageService.SendMessageToBackground(new StartPlaybackMessage());
                }
                else
                {
                    throw new Exception("Playlist is empty. Play playlist track failed.");
                }
            }
        }

        #region INotifyPropertyChanged implementation
        new public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
