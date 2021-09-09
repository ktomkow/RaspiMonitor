using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebService.Measurers;

namespace WebService.MeasurementService
{
    public class MonitoringService : BackgroundService
    {
        private readonly IEnumerable<IMeasurer> measurers;

        public MonitoringService(IEnumerable<IMeasurer> measurers)
        {
            this.measurers = measurers;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                if (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(5000);

                    foreach (var measurer in this.measurers)
                    {
                        await measurer.Measure();
                    }
                }
            }
        }
    }
}
