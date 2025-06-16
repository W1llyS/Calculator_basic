using System;
using System.Configuration;
using Serilog;
using Serilog.Events;

namespace Calculator_V1.Services
{
    public static class Logger
    {
        static Logger()
        {
            var logPath = ConfigurationManager.AppSettings["LogFilePath"]
                          ?? @"C:\Logs\CalculatorApp\logs-.txt";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: logPath,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();
        }

        public static void Information(string message, params object[] args)
        {
            Log.Information(message, args);
        }

        public static void Error(Exception ex, string message, params object[] args)
        {
            Log.Error(ex, message, args);
        }

        public static void Debug(string message, params object[] args)
        {
            Log.Debug(message, args);
        }

        public static void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
