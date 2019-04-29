using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LogApp.iOS.DependencyServices;
using NLog;
using NLog.Config;
using Prism.Logging;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(NLogLogger))]

namespace LogApp.iOS.DependencyServices
{
    public class NLogLogger : ILoggerFacade
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        static NLogLogger()
        {
            LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
            Logger = LogManager.GetCurrentClassLogger();
        }
        private static LogLevel CategoryToLogLevel(Category category)
        {
            switch (category)
            {
                case Category.Debug:
                    return LogLevel.Debug;

                case Category.Exception:
                    return LogLevel.Error;

                case Category.Info:
                    return LogLevel.Info;

                case Category.Warn:
                    return LogLevel.Warn;

                default:
                    return LogLevel.Off;
            }
        }

        public void Log(string message, Category category, Priority priority)
        {
            Logger.Log(CategoryToLogLevel(category), message);
        }

    }
}