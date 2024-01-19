
using System.Diagnostics.Metrics;

public class VersionService : IHostedService, IDisposable
{
    private bool disposedValue;

    public Meter meter { get; init; } = new("MeterName", "1.0.0");
    public Task StartAsync(CancellationToken cancellationToken)
    {
        
        var hatsSold = meter.CreateCounter<long>(
            name: "hats-sold",
            unit: "Hats",
            description: "The number of hats sold in our store");
        hatsSold.Add(1, [new("version", "1.0.0")]);

        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                meter.Dispose();
                Console.WriteLine("here");
            }

            // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
            // TODO: 큰 필드를 null로 설정합니다.
            disposedValue = true;
        }
    }

    // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
    // ~VersionService()
    // {
    //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
