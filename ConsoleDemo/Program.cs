// See https://aka.ms/new-console-template for more information
using OpenTelemetry;
using OpenTelemetry.Trace;
using System.Diagnostics;

ActivitySource MyActivitySource = new(
        "ConsoleDemo.Trace");

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("ConsoleDemo.Trace")
    .AddConsoleExporter()
    .Build();

using (var activity = MyActivitySource.StartActivity("ActivityStarted"))
{
    int StartNumber = 10000;
    activity?.SetTag("StartNumber", StartNumber);
    

    for (int i = 0; i < StartNumber; i++)
    {
        DoProcess(i);
    }

    activity?.SetStatus(ActivityStatusCode.Ok);
}

void DoProcess(int currentNumer)
{
    var doubleValue = currentNumer * 2;
}