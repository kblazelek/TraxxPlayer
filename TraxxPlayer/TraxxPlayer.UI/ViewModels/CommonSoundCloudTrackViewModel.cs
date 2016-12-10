using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;

namespace TraxxPlayer.UI.ViewModels
{
    public class CommonSoundCloudTrackViewModel : CommonViewModel
    {
        protected DelegateCommand addTrackToLikesCommand;
        public DelegateCommand AddTrackToLikesCommand => addTrackToLikesCommand ?? (addTrackToLikesCommand = new DelegateCommand(AddTrackToLikes));
        protected DelegateCommand<SoundCloudTrack> soundCloudTrackRightTappedCommand;
        public DelegateCommand<SoundCloudTrack> SoundCloudTrackRightTappedCommand => soundCloudTrackRightTappedCommand ?? (soundCloudTrackRightTappedCommand = new DelegateCommand<SoundCloudTrack>(TrackRightTapped));
        protected SoundCloudTrack rightTappedTrack = null;
        public ObservableCollection<PlaylistToDisplay> Playlists { get; set; } = new ObservableCollection<PlaylistToDisplay>();
        protected DelegateCommand<PlaylistToDisplay> addTrackToPlaylistCommand;
        public DelegateCommand<PlaylistToDisplay> AddTrackToPlaylistCommand => addTrackToPlaylistCommand ?? (addTrackToPlaylistCommand = new DelegateCommand<PlaylistToDisplay>(AddTrackToPlaylist));
        public void AddTrackToLikes()
        {
            try
            {
                if (rightTappedTrack != null)
                {
                    LikeService.AddLike(new LikeToAdd() { UserID = App.User.id, TrackID = rightTappedTrack.id });
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        public void AddTrackToPlaylist(PlaylistToDisplay playlistSelected)
        {
            try
            {
                if (rightTappedTrack != null && playlistSelected != null)
                {
                    PlaylistTrackService.AddPlaylistTrack(new PlaylistTrackToAdd() { PlaylistID = playlistSelected.id, TrackID = rightTappedTrack.id });
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        public void TrackRightTapped(SoundCloudTrack track)
        {
            rightTappedTrack = track;
        }

        public CommonSoundCloudTrackViewModel()
        {
            foreach (var p in PlaylistService.GetPlaylists(App.User.id))
            {
                Playlists.Add(p);
            }
        }
    }
}
