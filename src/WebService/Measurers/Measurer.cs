using System.Threading.Tasks;
using WebService.Metrics;

namespace WebService.Measurers
{
    public abstract class Measurer<T> : IMeasurer
    {
        private readonly Summaries summaries;

        public Measurer(Summaries summaries)
        {
            this.summaries = summaries;
        }

        public async Task Measure()
        {
            T value = await this.ReadValue();

            await this.Report(value);
        }

        protected virtual string Metric()
        {
            return this.GetType().Name;
        }

        protected abstract Task<T> ReadValue();

        private async Task Report(T value)
        {
            string metric = this.Metric();

            this.summaries.Report(metric, Map(value));

            await Task.CompletedTask;
        }

        private double Map(T value)
        {
            double.TryParse(value.ToString(), out var result);

            return result;
        }

    }
}
