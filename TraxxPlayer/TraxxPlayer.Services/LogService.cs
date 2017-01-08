using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraxxPlayer.Data;
using TraxxPlayer.Services.Helpers;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Services
{
    public static class LogService
    {
        /// <summary>
        /// Gets all logs for user from database
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static IEnumerable<LogToDisplay> GetLogs(int userID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Logs.Where(l => l.UserID == userID).Select(x => new LogToDisplay(x.UserID, (LogMessageType)x.MessageType, x.Source, x.Message)).ToList();
            }
        }

        /// <summary>
        /// Gets specific logs for user from database
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static IEnumerable<LogToDisplay> GetLogs(int userID, LogMessageType messageType)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Logs.Where(log => log.UserID == userID && log.MessageType == (int)messageType).Select(x => new LogToDisplay(x.UserID, (LogMessageType)x.MessageType, x.Source, x.Message)).ToList();
            }
        }

        /// <summary>
        /// Gets all logs for user from database with record limit
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recordLimit"></param>
        /// <returns></returns>
        public static IEnumerable<LogToDisplay> GetLogs(int userID, int recordLimit)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Logs.Where(log => log.UserID == userID).OrderByDescending(l => l.CreationDate).Take(recordLimit).Select(x => new LogToDisplay(x.UserID, (LogMessageType)x.MessageType, x.Source, x.Message)).ToList();
            }
        }

        /// <summary>
        /// Gets specific logs for user from database with record limit
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="messageType"></param>
        /// <param name="recordLimit"></param>
        /// <returns></returns>
        public static IEnumerable<LogToDisplay> GetLogs(int userID, LogMessageType messageType, int recordLimit)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Logs.Where(log => log.UserID == userID && log.MessageType == (int)messageType).OrderByDescending(l => l.CreationDate).Take(recordLimit).Select(x => new LogToDisplay(x.UserID, (LogMessageType)x.MessageType, x.Source, x.Message)).ToList();
            }
        }

        /// <summary>
        /// Gets single log from database
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        public static LogToDisplay GetLog(int logID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var log = db.Logs.Where(l => l.id == logID).FirstOrDefault();
                if (log != null)
                {
                    return new LogToDisplay(log.UserID, (LogMessageType)log.MessageType, log.Source, log.Message);
                }
                else
                {
                    throw new Exception("Log with the id provided does not exist. Get Log failed.");
                }
            }
        }

        /// <summary>
        /// Checks wheter log exists in database
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        public static bool LogExist(int logID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Logs.Any(l => l.id == logID);
            }
        }

        /// <summary>
        /// Modifies log in database
        /// </summary>
        /// <param name="log"></param>
        public static void ModifyLog(LogToDisplay log)
        {
            if (log != null)
            {
                using (var db = new TraxxPlayerContext())
                {
                    if (LogExist(log.id))
                    {
                        var logToModify = db.Logs.First(l => l.id == log.id);
                        logToModify.Message = log.Message;
                        logToModify.MessageType = log.MessageType;
                        logToModify.UserID = log.UserID;
                        logToModify.Source = log.Source;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Log with provided id doesn't exist. Modify Log failed");
                    }
                }
            }
            else
            {
                throw new Exception("Log cannot be null. Modify Log failed");
            }
        }

        /// <summary>
        /// Adds log to database
        /// </summary>
        /// <param name="log"></param>
        public static void AddLog(LogToAdd log)
        {
            using (var db = new TraxxPlayerContext())
            {
                if (log != null)
                {
                    db.Logs.Add(new Log(log.UserID, (int)log.MessageType, log.Source, log.Message));
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Log to add cannot be null. Add Log failed.");
                }
            }
        }

        /// <summary>
        /// Deletes log from database
        /// </summary>
        /// <param name="logID"></param>
        public static void DeleteLog(int logID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var logToDelete = db.Logs.Where(l => l.id == logID).FirstOrDefault();
                if (logToDelete != null)
                {
                    db.Logs.Remove(logToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Log with the id specified does not exist. Delete Log failed.");
                }
            }
        }
    }
}
