using System.Threading.Tasks;

namespace WebService.Measurers
{
    public class FakeMeasurer : Measurer<int>
    {
        protected override async Task<int> ReadValue()
        {
            return await Task.FromResult(5);
        }
    }
}
