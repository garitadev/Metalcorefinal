using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SB_Admin.Models
{
    public class LogModel
    {
        private static Logger Logger;
        public static void GetLogger()
        {


            string rutaTXT = ConfigurationManager.AppSettings["LogR"].ToString();
            if (Logger == null)
            {
                Logger = new LoggerConfiguration().
                              WriteTo.File(rutaTXT,
                              rollingInterval: RollingInterval.Day,
                              fileSizeLimitBytes: 10485760,
                              rollOnFileSizeLimit: true,
                              retainedFileCountLimit: 3)
                              .CreateLogger();
            }
        }

        public static void LogInfo(string mensaje)
        {
            GetLogger();
            Logger.Information(mensaje);

        }

        public static void LogError(string mensaje)
        {
            GetLogger();
            Logger.Error(mensaje);
        }

    }
}