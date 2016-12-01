using System;
using System.Runtime.Serialization;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class TrackChangedMessage
    {
        public TrackChangedMessage()
        {
        }

        public TrackChangedMessage(Uri trackId)
        {
            this.TrackId = trackId;
        }

        [DataMember]
        public Uri TrackId;
    }
}
