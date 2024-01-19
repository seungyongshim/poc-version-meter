using System.Diagnostics.Metrics;
using OpenTelemetry.Metrics;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenTelemetry()
    .WithMetrics(builder => builder
        .AddMeter("Aums.Metric")
        .AddPrometheusExporter());
builder.Services.AddHostedService<VersionService>();

var app = builder.Build();



app.MapPrometheusScrapingEndpoint();
await app.RunAsync();

