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
        public static void LogInfo(object sender, UserToDisplay user, string infoMessage, [CallerMemberName]string memberName = "")
        {
            var userID = user != null ? user.id : -1;
            LogService.AddLog(new Services.Helpers.LogToAdd(userID, Services.Helpers.LogMessageType.INFO, $"{sender.GetType()}.{memberName}", infoMessage));
            Debug.WriteLine($"INFO: {sender.GetType()}.{memberName}");
        }

        public static void LogWarning(object sender, UserToDisplay user, string warningMessage, [CallerMemberName]string memberName = "")
        {
            var userID = user != null ? user.id : -1;
            LogService.AddLog(new Services.Helpers.LogToAdd(userID, Services.Helpers.LogMessageType.WARNING, $"{sender.GetType()}.{memberName}", warningMessage));
            Debug.WriteLine($"WARNING: {sender.GetType()}.{memberName}");
        }

        public static void LogError(object sender, UserToDisplay user, string errorMessage, [CallerMemberName]string memberName = "")
        {
            var userID = user != null ? user.id : -1;
            LogService.AddLog(new Services.Helpers.LogToAdd(userID, Services.Helpers.LogMessageType.ERROR, $"{sender.GetType()}.{memberName}", errorMessage));
            Debug.WriteLine($"ERROR: {sender.GetType()}.{memberName}");
        }
    }
}
