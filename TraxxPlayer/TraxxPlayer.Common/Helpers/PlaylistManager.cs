﻿using TraxxPlayer.Common.Enums_and_constants;
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
using Windows.Media.Playback;
using System.Diagnostics;

namespace TraxxPlayer.Common.Helpers
{
    public class PlaylistManager : INotifyPropertyChanged
    {
        public ObservableCollection<SoundCloudTrack> Tracks { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public PlaylistToDisplay Playlist { get; set; }

        /// <summary>
        /// Plays playlist passed as a parameter
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
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
            List<PlaylistTrackToDisplay> deletedPlaylistTracks = new List<PlaylistTrackToDisplay>();
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
                    deletedPlaylistTracks.Add(t);
                }
            }
            MessageService.SendMessageToBackground(this, new UpdatePlaylistMessage(Tracks.ToList()));
            if (deletedPlaylistTracks.Count > 0)
            {
                foreach (var deletedPlaylistTrack in deletedPlaylistTracks)
                {
                    PlaylistTrackService.DeletePlaylistTrack(deletedPlaylistTrack.id);
                }
                for (int i = 0; i < Tracks.Count; ++i)
                {
                    var movedTrack = PlaylistTrackService.GetPlaylistTrack(Playlist.id, (int)Tracks[i].id);
                    movedTrack.TrackOrder = i;
                    PlaylistTrackService.ModifyPlaylistTrack(movedTrack);
                }
                throw new SoundCloudTrackNotAvailableException($"Some of your tracks were deleted from playlist {playlist.Name}, because they were no longer available on SoundCloud", deletedPlaylistTracks.Select(pt => pt.id).ToList());
            }
        }

        /// <summary>
        /// Handles track reordering
        /// </summary>
        public void ReorderTracks(SoundCloudTrack track, int indexFrom, int indexTo)
        {
            if (track == null)
            {
                throw new Exception("Track to remove is null. Reorder tracks from current playlist failed.");
            }
            if (Playlist == null)
            {
                throw new Exception("Playlist is null. Reorder tracks from current playlist failed.");
            }
            if (!Tracks.Contains(track))
            {
                throw new Exception($"There is no track with id {track.id} in current playlist. Reorder tracks from current playlist failed.");
            }
            var movedPlaylistTrack = PlaylistTrackService.GetPlaylistTrack(Playlist.id, (int)track.id);
            movedPlaylistTrack.TrackOrder = indexTo;
            PlaylistTrackService.ModifyPlaylistTrack(movedPlaylistTrack);
            if (indexTo - indexFrom > 0)
            {
                for (int i = indexFrom; i < indexTo; ++i)
                {
                    var movedTrack = PlaylistTrackService.GetPlaylistTrack(Playlist.id, (int)Tracks[i].id);
                    movedTrack.TrackOrder = i;
                    PlaylistTrackService.ModifyPlaylistTrack(movedTrack);
                }
            }
            else if (indexTo - indexFrom < 0)
            {
                for (int i = indexTo + 1; i <= indexFrom; ++i)
                {
                    var movedTrack = PlaylistTrackService.GetPlaylistTrack(Playlist.id, (int)Tracks[i].id);
                    movedTrack.TrackOrder = i;
                    PlaylistTrackService.ModifyPlaylistTrack(movedTrack);
                }
            }
        }

        /// <summary>
        /// Removes track from current playlist
        /// </summary>
        /// <param name="track"></param>
        public void RemoveTrackFromCurrentPlaylist(SoundCloudTrack track)
        {
            if (track == null)
            {
                throw new Exception("Track to remove is null. Remove track from current playlist failed.");
            }
            if (Playlist == null)
            {
                throw new Exception("Playlist is null. Remove track from current playlist failed.");
            }
            if (!Tracks.Contains(track))
            {
                throw new Exception($"There is no track with id {track.id} in current playlist. Remove track from current playlist failed.");
            }
            // Remove later when syncing with background task
            Tracks.Remove(track);
            MessageService.SendMessageToBackground(this, new DeleteTrackFromPlaybackList(track));
        }

        /// <summary>
        /// Extracts stream url from uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static string GetStreamUrlFromUri(string uri)
        {
            return uri + "/stream?client_id=" + SoundCloudConstants.SoundCloudClientId;
        }

        /// <summary>
        /// Cleans current playlist and plays single track
        /// </summary>
        /// <param name="track"></param>
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
                MessageService.SendMessageToBackground(this, new UpdatePlaylistMessage(new List<SoundCloudTrack> { track }));
            }
            Tracks.Clear();
            Tracks.Add(track);
        }

        /// <summary>
        /// Cleans current playlist and plays multiple tracks
        /// </summary>
        /// <param name="tracks"></param>
        public void PlayTracks(List<SoundCloudTrack> tracks)
        {
            if (tracks == null)
            {
                throw new Exception("Track is empty. Play track failed.");
            }
            if (tracks.Count == 0)
            {
                throw new Exception("Track is empty. Play track failed.");
            }
            Tracks.Clear();
            foreach (var track in tracks)
            {
                if (track.stream_url == null && track.uri != null)
                {
                    track.stream_url = GetStreamUrlFromUri(track.uri);
                }
                if (track.stream_url != null)
                {
                    Tracks.Add(track);
                }
            }
            MessageService.SendMessageToBackground(this, new UpdatePlaylistMessage(Tracks.ToList()));
        }

        /// <summary>
        /// Play single track from current playlist
        /// </summary>
        /// <param name="track"></param>
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
                if (Tracks.Where(t => t.id == track.id).FirstOrDefault() != null)
                {
                    MessageService.SendMessageToBackground(this, new TrackChangedMessage(new Uri(track.stream_url)));
                    MessageService.SendMessageToBackground(this, new StartPlaybackMessage());
                }
                else
                {
                    throw new Exception("Playlist is empty. Play playlist track failed.");
                }
            }
        }

        /// <summary>
        /// Stops playing
        /// </summary>
        public void StopPlayer()
        {
            Tracks.Clear();
            Playlist = null;
            MessageService.SendMessageToBackground(this, new ShutdownBackgroundMediaPlayer());
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
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
