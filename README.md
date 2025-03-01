# Health Check API

This is a basic .NET Core API implementing health checks using `Microsoft.Extensions.Diagnostics.HealthChecks`. It provides endpoints to monitor the application's health status.

## Prerequisites

- .NET 9.
- Visual Studio / VS Code / Any C# IDE

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/fkucukkara/healthCheckWorkshop.git
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the application:
   ```sh
   dotnet build
   ```

## Running the Application

To run the application, use the following command:
```sh
   dotnet run
```

## Health Check Endpoints

The API exposes two health check endpoints:

- **Liveness Probe**: Checks if the service is running.
  ```
  GET /healthz/live
  ```
- **Readiness Probe**: Checks if the primary services are ready.
  ```
  GET /healthz/ready
  ```

## Implementation Details

- **Primary Health Check**: Implemented via `SamplePrimaryCheckService`, marked with the tag `primary`.
- **Secondary Health Check**: Implemented via `SampleSecondaryCheckService`, marked with the tag `secondary`.
- `HealthStatus.Degraded` is used as a failure status for both health checks.
- Health checks are mapped using `MapHealthChecks` in `Program.cs`.

## HTTPS Redirection

The application forces HTTPS redirection using `app.UseHttpsRedirection();` to ensure secure communication.

## Extending Health Checks

You can add custom health checks by implementing `IHealthCheck`:

```csharp
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

public class CustomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(HealthCheckResult.Healthy("Custom check is healthy"));
    }
}
```

Register it in `Program.cs`:
```csharp
builder.Services.AddHealthChecks()
    .AddCheck<CustomHealthCheck>("CustomCheck");
```

## License
[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

This project is licensed under the MIT License. See the [`LICENSE`](LICENSE) file for details.