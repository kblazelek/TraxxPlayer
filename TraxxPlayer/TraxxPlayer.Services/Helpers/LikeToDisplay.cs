using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Services.Helpers
{
    public class LikeToDisplay
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public int TrackID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
