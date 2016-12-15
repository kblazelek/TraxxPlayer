using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Services;

namespace TraxxPlayer.Common.Helpers
{
    public static class Logger
    {
        public static void LogInfo(object sender, int userID, string infoMessage, [CallerMemberName]string memberName = "")
        {
            LogService.AddLog(new Services.Helpers.LogToAdd(userID, Services.Helpers.LogMessageType.INFO, $"{sender.GetType()}.{memberName}", infoMessage));
        }

        public static void LogWarning(object sender, int userID, string warningMessage, [CallerMemberName]string memberName = "")
        {
            LogService.AddLog(new Services.Helpers.LogToAdd(userID, Services.Helpers.LogMessageType.WARNING, $"{sender.GetType()}.{memberName}", warningMessage));
        }

        public static void LogError(object sender, int userID, string errorMessage, [CallerMemberName]string memberName = "")
        {
            LogService.AddLog(new Services.Helpers.LogToAdd(userID, Services.Helpers.LogMessageType.ERROR, $"{sender.GetType()}.{memberName}", errorMessage));
        }
    }
}
