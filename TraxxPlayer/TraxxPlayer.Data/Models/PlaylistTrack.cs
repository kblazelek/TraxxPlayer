using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Data.Models
{
    public class PlaylistTrack
    {
        public int id { get; set; }

        [ForeignKey("Playlist")]
        public int PlaylistID { get; set; }

        public int TrackOrder { get; set; }
        public int TrackID { get; set; }
        public Playlist Playlist { get; set; }
    }
}
