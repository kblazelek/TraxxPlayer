using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;

namespace TraxxPlayer.Common.Helpers
{
    public static class Logger
    {
        public static UserToDisplay User;

        /// <summary>
        /// Logs information to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="infoMessage"></param>
        /// <param name="memberName"></param>
        public static void LogInfo(object sender, string infoMessage, [CallerMemberName]string memberName = "")
        {
            int? userID = User != null ? User.id : (int?)null;
            LogService.AddLog(new LogToAdd(userID, LogMessageType.INFO, $"{sender.GetType()}.{memberName}", infoMessage));
            Debug.WriteLine($"INFO: {sender.GetType()}.{memberName}");
        }

        /// <summary>
        /// Logs warning to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="warningMessage"></param>
        /// <param name="memberName"></param>
        public static void LogWarning(object sender, string warningMessage, [CallerMemberName]string memberName = "")
        {
            int? userID = User != null ? User.id : (int?)null;
            LogService.AddLog(new LogToAdd(userID, LogMessageType.WARNING, $"{sender.GetType()}.{memberName}", warningMessage));
            Debug.WriteLine($"WARNING: {sender.GetType()}.{memberName}");
        }

        /// <summary>
        /// Logs error to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="errorMessage"></param>
        /// <param name="memberName"></param>
        public static void LogError(object sender, string errorMessage, [CallerMemberName]string memberName = "")
        {
            int? userID = User != null ? User.id : (int?)null;
            LogService.AddLog(new LogToAdd(userID, LogMessageType.ERROR, $"{sender.GetType()}.{memberName}", errorMessage));
            Debug.WriteLine($"ERROR: {sender.GetType()}.{memberName}");
        }
    }
}
