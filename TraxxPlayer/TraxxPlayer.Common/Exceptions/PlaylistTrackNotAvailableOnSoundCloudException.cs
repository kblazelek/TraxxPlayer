using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using TraxxPlayer.Services.Helpers;

namespace TraxxPlayer.Common.Exceptions
{
    public class PlaylistTrackNotAvailableOnSoundCloudException : Exception
    {
        public List<PlaylistTrackToDisplay> DeletedTracks;
        public PlaylistTrackNotAvailableOnSoundCloudException()
        {
            
        }

        public PlaylistTrackNotAvailableOnSoundCloudException(string message, List<PlaylistTrackToDisplay> deletedTracks)
            : base(message + ". Deleted track ids: " + deletedTracks.Select(dt => dt.TrackID.ToString()).Join())
        {
            DeletedTracks = deletedTracks;
        }

        public PlaylistTrackNotAvailableOnSoundCloudException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
