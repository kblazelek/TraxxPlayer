using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundAudioShared.Models
{
    public class SoundCloudChart
    {
        public string genre { get; set; }
        public string kind { get; set; }
        public string last_updated { get; set; }
        public List<SoundCloudTrackScore> collection { get; set; }
        public string query_urn { get; set; }
        public string next_href { get; set; }
    }
}
