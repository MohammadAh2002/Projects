using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomHealthCheck : IHealthCheck
    {
        private Random _Random = new Random();

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {

            int responseTime = _Random.Next(1, 300);

            return await Task.FromResult(responseTime switch
            {
                < 100 => HealthCheckResult.Healthy("Healthy result from CustomHealthCheck"),
                (> 100) and (< 200) => HealthCheckResult.Degraded("Degraded result from CustomHealthCheck"),
                _ => HealthCheckResult.Unhealthy("Unhealthy result from CustomHealthCheck")
            });

        }
    }
}
