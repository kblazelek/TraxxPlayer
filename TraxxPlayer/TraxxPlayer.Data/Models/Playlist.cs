using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Data.Models
{
    public class Playlist
    {
        public int id { get; set; }
        public string Name { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }

        public Playlist()
        {
            CreationDate = DateTime.Now;
        }
    }
}
