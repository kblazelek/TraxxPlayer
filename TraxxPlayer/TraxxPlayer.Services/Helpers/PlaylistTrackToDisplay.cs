using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Services.Helpers
{
    public class PlaylistTrackToDisplay
    {
        public int id { get; set; }
        public int PlaylistID { get; set; }
        public int TrackOrder { get; set; }
        public int TrackID { get; set; }
    }
}
