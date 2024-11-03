using System;
using Destructurama;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;

namespace NoreBaseApiChallenge.Domain.shared;

public static class Logger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure => (context, configuration) =>
    {
        ITextFormatter jsonFomatter = new Serilog.Formatting.Json.JsonFormatter(renderMessage: true);

        configuration
            .Destructure.UsingAttributes()
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .MinimumLevel.ControlledBy(new Serilog.Core.LoggingLevelSwitch())
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day, shared: true)
            .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
            .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
            .ReadFrom.Configuration(context.Configuration);
    };
}
