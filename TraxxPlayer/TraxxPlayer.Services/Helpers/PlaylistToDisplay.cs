using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Services.Helpers
{
    public class PlaylistToDisplay
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
