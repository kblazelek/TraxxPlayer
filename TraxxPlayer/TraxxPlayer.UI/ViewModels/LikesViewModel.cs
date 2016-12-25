using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TraxxPlayer.Common.Helpers;
using TraxxPlayer.Common.Messages;
using TraxxPlayer.Common.Models;
using TraxxPlayer.Services;
using Windows.UI.Xaml.Controls;

namespace TraxxPlayer.UI.ViewModels
{
    public class LikesViewModel : CommonSoundCloudTrackViewModel
    {
        public ObservableCollection<SoundCloudTrack> Likes { get; set; } = new ObservableCollection<SoundCloudTrack>();
        public LikesViewModel()
        {
            GetLikes();
        }

        private async void GetLikes()
        {
            try
            {
                var likesTrackIDs = LikeService.GetLikes(App.User.id).Select(l => l.TrackID).ToList();
                if (likesTrackIDs.Count > 0)
                {
                    foreach (var trackID in likesTrackIDs)
                    {
                        var track = await SoundCloudHelper.GetSoundCloudTrack(trackID);
                        Likes.Add(track);
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(this, ex.Message);
                ShowErrorMessage("There was an error during getting licked tracks.");
            }
        }
    }
}
