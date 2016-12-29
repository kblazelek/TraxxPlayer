using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using TraxxPlayer.Services.Helpers;

namespace TraxxPlayer.Common.Exceptions
{
    public class SoundCloudTrackNotAvailableException : Exception
    {
        public List<int> DeletedTracksIDs;
        public SoundCloudTrackNotAvailableException()
        {
            
        }

        public SoundCloudTrackNotAvailableException(string message, List<int> deletedTracks)
            : base(message + ". Deleted track ids: " + deletedTracks.Select(id => id.ToString()).Join())
        {
            DeletedTracksIDs = deletedTracks;
        }

        public SoundCloudTrackNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
