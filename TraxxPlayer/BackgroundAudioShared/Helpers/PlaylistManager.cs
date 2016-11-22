using BackgroundAudioShared.Enums_and_constants;
using BackgroundAudioShared.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI.Xaml.Controls;

namespace BackgroundAudioShared.Helpers
{
    public class PlaylistManager : INotifyPropertyChanged
    {
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public PlaylistToDisplay Playlist { get; set; }

        public async Task PlayPlaylist(PlaylistToDisplay playlist)
        {
            if(playlist != null)
            {
                Playlist = playlist;
                // Clear tracks from current playlist
                Tracks.Clear();
                var tracks = PlaylistTrackService.GetPlaylistTracks(playlist.id).OrderBy(pt => pt.TrackOrder);
                if(tracks != null)
                {
                    if(tracks.Count() > 0)
                    {
                        foreach(var t in tracks)
                        {
                            var tempTrack = await SoundCloudHelper.GetSoundCloudTrack(t.TrackID);
                            if(tempTrack != null)
                            {
                                Tracks.Add(tempTrack);
                            }
                        }
                        MessageService.SendMessageToBackground(new UpdatePlaylistMessage(Tracks.ToList()));
                        MessageService.SendMessageToBackground(new StartPlaybackMessage());
                    }
                    else
                    {
                        throw new Exception("Playlist does not contain any tracks.");
                    }
                }
                else
                {
                    throw new Exception("There was an error during fetching tracks for playlist. Play playlist failed.");
                }
            }
        }
        public void PlayTrack(SoundCloudTrack track)
        {
            if (track.stream_url == null && track.uri != null)
            {
                track.stream_url = track.uri + "/stream?client_id=" + SoundCloudConstants.SoundCloudClientId;
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
                    MessageService.SendMessageToBackground(new UpdatePlaylistMessage(new List<SoundCloudTrack> { track }));
                    MessageService.SendMessageToBackground(new StartPlaybackMessage());
                }
            }
        }

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
    }
}
