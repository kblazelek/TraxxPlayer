using System.Collections.Generic;

namespace TraxxPlayer.Common.Models
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
