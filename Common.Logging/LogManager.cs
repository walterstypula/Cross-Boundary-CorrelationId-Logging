using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.IO;
using System.Text;
using System.Web.Hosting;

namespace Common.Logging
{
    public static class LogManager
    {
        static LogManager()
        {
            SetupLogger();
        }

        public static ILogger GetLogger(Type type)
        {
            return new Logger(type);
        }

        private static string GetApplicationName()
        {
            var appName = string.Empty;
            if(HostingEnvironment.IsHosted)
            {
                var virtualPath = HostingEnvironment.ApplicationVirtualPath;
                appName = string.Format("{0}.{1}", HostingEnvironment.SiteName, virtualPath).Replace("/", string.Empty);
            }
            else
            {
                appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            }

            return string.Format("Logging.{0}",appName).Trim('.');
        }

        private static void SetupLogger()
        {
            Hierarchy hierarchy = (Hierarchy)log4net.LogManager.GetRepository();
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var applicationName = GetApplicationName() + ".txt";

            var fileAppender = GetFileAppender(Path.Combine(desktopPath, applicationName));
            BasicConfigurator.Configure(fileAppender);

            hierarchy.Root.Level = Level.All;
        }

        private static IAppender GetConsoleAppender()
        {
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            var console = new ConsoleAppender();
            console.Layout = patternLayout;
            console.ActivateOptions();

            return console;
        }

        private static IAppender GetFileAppender(string logFilePath)
        {
            var layout  = new PatternLayout("%date [%thread] %-5level %logger - %message%newline");
            layout.ActivateOptions();

            var appender = new FileAppender
            {
                File = logFilePath,
                Encoding = Encoding.UTF8,
                Threshold = Level.All,
                Layout = layout
            };

            appender.ActivateOptions();
            return appender;
        }
    }
}
