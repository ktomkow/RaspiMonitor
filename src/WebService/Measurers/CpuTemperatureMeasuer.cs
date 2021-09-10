using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebService.Metrics;

namespace WebService.Measurers
{
    public class CpuTemperatureMeasuer : Measurer<double>
    {
        private Iot.Device.CpuTemperature.CpuTemperature measurer;
        private readonly ILogger<CpuTemperatureMeasuer> logger;

        public CpuTemperatureMeasuer(Iot.Device.CpuTemperature.CpuTemperature measurer, Summaries summaries, ILogger<CpuTemperatureMeasuer> logger) : base(summaries)
        {
            this.measurer = measurer;
            this.logger = logger;
        }

        protected override async Task<double> ReadValue()
        {
            double temperature = measurer.Temperature.DegreesCelsius;
            this.logger.LogInformation($"Temperature: {temperature}∘C");
            return await Task.FromResult(temperature);
        }
    }
}
