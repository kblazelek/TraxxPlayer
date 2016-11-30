using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundAudioShared.Messages
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
