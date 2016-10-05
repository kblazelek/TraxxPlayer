using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Media;

namespace BackgroundAudioShared.Messages
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
