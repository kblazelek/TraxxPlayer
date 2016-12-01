using System;
using System.Runtime.Serialization;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class AppResumedMessage
    {
        public AppResumedMessage()
        {
            this.Timestamp = DateTime.Now;
        }

        public AppResumedMessage(DateTime timestamp)
        {
            this.Timestamp = timestamp;
        }

        [DataMember]
        public DateTime Timestamp;
    }
}
