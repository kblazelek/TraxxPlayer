using System.Runtime.Serialization;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class DeviceFamilyMessage
    {
        public DeviceFamilyMessage()
        {
        }

        public DeviceFamilyMessage(string deviceFamily)
        {
            this.DeviceFamily = deviceFamily;
        }

        [DataMember]
        public string DeviceFamily;
    }
}
