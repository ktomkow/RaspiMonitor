using System.Threading.Tasks;

namespace WebService.Measurers
{
    public interface IMeasurer
    {
        public Task Measure();
    }
}
