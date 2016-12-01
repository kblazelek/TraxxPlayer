using System.Runtime.Serialization;
using Windows.Media;

namespace TraxxPlayer.Common.Messages
{
    [DataContract]
    public class UVCButtonPressedMessage
    {
        public UVCButtonPressedMessage()
        {

        }

        public UVCButtonPressedMessage(SystemMediaTransportControlsButton button)
        {
            Button = button;
        }

        [DataMember]
        public SystemMediaTransportControlsButton Button;
    }
}
