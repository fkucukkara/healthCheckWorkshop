using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace healthcheckWorkshop.Services;

public class SampleSecondaryCheckService : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = true;

        // ...

        if (isHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("[Secondary] A healthy result."));
        }

        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "[Secondary] An unhealthy result."));
    }
}
