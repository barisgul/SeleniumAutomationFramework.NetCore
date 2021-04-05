using Serilog;
using System;

namespace Framework.Common
{
    public static class Logger
    {
        
        static Logger()
        {
            #region Write logs to log.txt file under the configuration folder 
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            #endregion

            #region Get logger configuration from appsettings.json file if will be deploy to a remote machine
            /*
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
            */
            #endregion

            #region use Elastic Common Scheme for Kibana if needed
            /*             
            var formatterConfig = new EcsTextFormatterConfiguration();
            formatterConfig.MapCurrentThread(true);

            var formatter = new EcsTextFormatter(formatterConfig); 

            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console(formatter)
                        .CreateLogger(); */
            #endregion
        }

        public static void Info(string logText)
        {
            Log.Information(logText);
        }

        public static void Info(string logText, params object[] obj)
        {
            Log.Information(logText, obj);
        }

        public static void Debug(string logText)
        {
            Log.Debug(logText);
        }

        public static void Debug(string logText, params object[] obj)
        {
            Log.Debug(logText, obj);
        }

        public static void Error(string logText, params object[] obj)
        {
            Log.Error(logText, obj);
        }

        public static void Error(string logText, Exception ex)
        {
            Log.Error(logText, ex);
        }
    }
}
