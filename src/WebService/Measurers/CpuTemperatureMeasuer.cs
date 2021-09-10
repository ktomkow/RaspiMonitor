using System.Threading.Tasks;
using WebService.Metrics;

namespace WebService.Measurers
{
    public class CpuTemperatureMeasuer : Measurer<double>
    {
        private Iot.Device.CpuTemperature.CpuTemperature measurer;

        public CpuTemperatureMeasuer(Iot.Device.CpuTemperature.CpuTemperature measurer, Summaries summaries) : base(summaries)
        {
            this.measurer = measurer;
        }

        protected override async Task<double> ReadValue()
        {
            return await Task.FromResult(measurer.Temperature.DegreesCelsius);
        }
    }
}
