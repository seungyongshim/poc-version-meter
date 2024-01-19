using OpenTelemetry.Metrics;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<VersionService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenTelemetry()
                .WithMetrics(builder => builder.AddMeter("Aums.Metric")
                                               .AddPrometheusExporter());

var app = builder.Build();

app.MapPrometheusScrapingEndpoint();
await app.RunAsync();

