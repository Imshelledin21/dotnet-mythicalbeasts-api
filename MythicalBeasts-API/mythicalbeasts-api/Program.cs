using Grafana.OpenTelemetry;
using OpenTelemetry.Metrics;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


if (Environment.GetEnvironmentVariable("CODE_INSTRUMENTATION") == "true")
{
    builder.Services.AddOpenTelemetry()
        .WithTracing(configure =>
        {
            configure.UseGrafana();
        });
    builder.Services.UseHttpClientMetrics();
}


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (Environment.GetEnvironmentVariable("CODE_INSTRUMENTATION") == "true")
{
    app.UseRouting();
    app.UseHttpMetrics();
    app.UseEndpoints(endpoints => { endpoints.MapMetrics(); });
}

app.Run();
