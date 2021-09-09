using System.Threading.Tasks;

namespace WebService.Measurers
{
    public abstract class Measurer<T> : IMeasurer
    {
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
            await Task.CompletedTask;
        }



    }
}
