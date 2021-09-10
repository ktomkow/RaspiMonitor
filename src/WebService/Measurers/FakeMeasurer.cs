using System.Threading.Tasks;
using WebService.Metrics;

namespace WebService.Measurers
{
    public class FakeMeasurer : Measurer<int>
    {
        public FakeMeasurer(Summaries summaries) : base(summaries)
        {
        }

        protected override async Task<int> ReadValue()
        {
            return await Task.FromResult(5);
        }
    }
}
