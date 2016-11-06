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
using Windows.UI.Xaml.Controls;

namespace BackgroundAudioShared.Helpers
{
    public class PlaylistManager : INotifyPropertyChanged
    {
        private ObservableCollection<SoundCloudTrack> currentPlaylist = new ObservableCollection<SoundCloudTrack>();

        public ObservableCollection<SoundCloudTrack> CurrentPlaylist
        {
            get { return currentPlaylist; }
            set { currentPlaylist = value; OnPropertyChanged(nameof(CurrentPlaylist)); }
        }

        public void PlayTrack(SoundCloudTrack track)
        {
            if (track.stream_url == null && track.uri != null)
            {
                track.stream_url = track.uri + "/stream?client_id=" + SoundCloudConstants.SoundCloudClientId;
            }
            if (track.stream_url != null)
            {
                if (CurrentPlaylist.Contains(track))
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
