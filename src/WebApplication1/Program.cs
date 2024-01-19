using System.Diagnostics.Metrics;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenTelemetry()
    .WithMetrics(builder => builder
        .AddMeter("MeterName")
        .AddPrometheusExporter());
builder.Services.AddHostedService<VersionService>();

var app = builder.Build();



app.MapPrometheusScrapingEndpoint();
await app.RunAsync();

