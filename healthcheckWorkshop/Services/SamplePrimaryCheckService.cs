using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace healthcheckWorkshop.Services;

public class SamplePrimaryCheckService : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = true;

        // ...

        if (isHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("[Primary] A healthy result."));
        }

        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "[Primary] An unhealthy result."));
    }
}
