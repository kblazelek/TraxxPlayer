using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Data.Models
{
    public class Log
    {
        public int id { get; set; }
        public int MessageType { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public User User { get; set; }

        public Log(int? userID, int messageType, string source, string message)
        {
            UserID = userID;
            MessageType = messageType;
            Message = message;
            CreationDate = DateTime.Now;
            Source = source;
        }
    }
}
