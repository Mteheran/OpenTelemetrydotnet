// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(options =>
            {
                options.AddConsoleExporter();
            });
});

var logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Hello community");
