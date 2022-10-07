// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using OpenTelemetry;
using OpenTelemetry.Metrics;

Meter MyMeter = new("ConsoleDemo.Metrics", "1.0");

Counter<long> RequestCounter = MyMeter.CreateCounter<long>("RequestCounter");

using var meterProvider = Sdk.CreateMeterProviderBuilder()
            .AddMeter("ConsoleDemo.Metrics")
            .AddConsoleExporter()
            .Build();

RequestCounter.Add(1, new KeyValuePair<string, object?>("POST Request", HttpMethod.Post));
RequestCounter.Add(1, new KeyValuePair<string, object?>("GET Request", HttpMethod.Get));
RequestCounter.Add(1, new KeyValuePair<string, object?>("GET Request", HttpMethod.Get));
RequestCounter.Add(1, new KeyValuePair<string, object?>("POST Request", HttpMethod.Post));
RequestCounter.Add(1, new KeyValuePair<string, object?>("PUT Request", HttpMethod.Put));

