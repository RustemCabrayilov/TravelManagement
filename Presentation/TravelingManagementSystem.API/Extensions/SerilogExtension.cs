using Serilog;

namespace TravelingManagementSystem.API.Extensions;

public static class SerilogExtension
{
    public static void AddSerilog(this ILoggingBuilder logBuilder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("serilog-config.json")
                .Build())
            .Enrich.FromLogContext()
            .CreateLogger();
        logBuilder.ClearProviders();
        logBuilder.AddSerilog(logger);
    }
}