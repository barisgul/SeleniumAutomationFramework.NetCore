using Elastic.CommonSchema.Serilog;
using Serilog;
using System;

namespace Framework.Common
{
    public static class Logger
    {
        static Logger()
        {
            var formatterConfig = new EcsTextFormatterConfiguration();
            formatterConfig.MapCurrentThread(true);

            var formatter = new EcsTextFormatter(formatterConfig);


            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console(formatter)
                        .CreateLogger();
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
