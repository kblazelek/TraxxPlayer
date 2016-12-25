using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Services.Helpers
{
    public class LogToAdd
    {
        public LogMessageType MessageType { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserID { get; set; }
        public string Source { get; set; }

        public LogToAdd(int? userID, LogMessageType messageType, string source, string message)
        {
            UserID = userID;
            MessageType = messageType;
            Message = message;
            CreationDate = DateTime.Now;
            Source = source;
        }
    }
}
