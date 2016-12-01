using System.Runtime.Serialization;
using TraxxPlayer.Common.Models;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class DeleteTrackFromPlaybackList
    {
        public DeleteTrackFromPlaybackList(SoundCloudTrack track)
        {
            this.Track = track;
        }

        [DataMember]
        public SoundCloudTrack Track;
    }
}
