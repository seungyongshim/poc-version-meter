
using System.Diagnostics.Metrics;

public class VersionService(IMeterFactory meterFactory) : IHostedService
{

    public Meter Meter { get; init; } = meterFactory.Create("Aums.Metric");
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var hatsSold = Meter.CreateCounter<long>(
            name: "application.version",
            description: "application version");
        hatsSold.Add(1, [new("app.version", "1.0.0")]);

        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
