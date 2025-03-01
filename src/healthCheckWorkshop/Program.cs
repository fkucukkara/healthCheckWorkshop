using healthcheckWorkshop.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddTypeActivatedCheck<SamplePrimaryCheckService>(
        "Primary",
        failureStatus: HealthStatus.Degraded,
        tags: ["primary"])
    .AddTypeActivatedCheck<SampleSecondaryCheckService>(
        "Secondary",
        failureStatus: HealthStatus.Degraded,
        tags: ["secondary"]);

var app = builder.Build();

app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("primary")
});

app.MapHealthChecks("/healthz/live");

app.UseHttpsRedirection();

app.Run();
