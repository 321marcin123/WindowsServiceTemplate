using Autofac;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.IO;

namespace Common.Config.ContainerBuilderExtensions
{
    public static class SerilogExtensions
    {
        public static void RegisterSerilog(this ContainerBuilder builder)
        {


            builder.Register<ILogger>(
                (c, p) =>
                {

                    var rollingFilePath = AppDomain.CurrentDomain.BaseDirectory + "/_logs/";
                    var iss = Directory.Exists(rollingFilePath);

                    rollingFilePath += " / Log-{Date}.txt";

                    var levelSwitch = new LoggingLevelSwitch();
                    levelSwitch.MinimumLevel = LogEventLevel.Information;

                    var tmplogger = new LoggerConfiguration()
                        .ReadFrom.AppSettings()
                        .WriteTo.RollingFile(rollingFilePath)
                        .WriteTo.Console()
                         .MinimumLevel.ControlledBy(levelSwitch)
                        .CreateLogger();
                    return tmplogger;

                }).SingleInstance();

        }
    }
}
