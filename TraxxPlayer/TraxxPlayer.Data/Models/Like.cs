using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Data.Models
{
    public class Like
    {
        public int id { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public int TrackID { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }

        public Like()
        {
            this.CreationDate = DateTime.Now;
        }
    }
}
