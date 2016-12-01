using System;
using System.Runtime.Serialization;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class AppSuspendedMessage
    {
        public AppSuspendedMessage()
        {
            this.Timestamp = DateTime.Now;
        }

        public AppSuspendedMessage(DateTime timestamp)
        {
            this.Timestamp = timestamp;
        }

        [DataMember]
        public DateTime Timestamp;
    }
}
