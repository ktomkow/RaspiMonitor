using System.Threading.Tasks;

namespace WebService.Measurers
{
    public class CpuTemperatureMeasuer : Measurer<double>
    {
        private Iot.Device.CpuTemperature.CpuTemperature measurer;

        public CpuTemperatureMeasuer(Iot.Device.CpuTemperature.CpuTemperature measurer)
        {
            this.measurer = measurer;
        }

        protected override async Task<double> ReadValue()
        {
            return await Task.FromResult(measurer.Temperature.DegreesCelsius);
        }
    }
}
