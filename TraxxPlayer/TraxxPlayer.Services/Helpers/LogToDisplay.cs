using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Services.Helpers
{
    public class LogToDisplay
    {
        public int id { get; set; }
        public int MessageType { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public string Source { get; set; }
        public int UserID { get; set; }

        public LogToDisplay(int userID, LogMessageType messageType, string source, string message)
        {
            UserID = userID;
            MessageType = (int)messageType;
            Message = message;
            CreationDate = DateTime.Now;
            Source = source;
        }
}
}
