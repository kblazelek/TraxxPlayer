using System.Collections.Generic;
using System.Runtime.Serialization;
using TraxxPlayer.Common.Models;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class UpdatePlaylistMessage
    {
        public UpdatePlaylistMessage(List<SoundCloudTrack> songs)
        {
            this.Songs = songs;
        }
        
        [DataMember]
        public List<SoundCloudTrack> Songs;
    }
}
