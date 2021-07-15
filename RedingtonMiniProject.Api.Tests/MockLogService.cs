using RedingtonMiniProject.Api.Logging;
using RedingtonMiniProject.Api.Models;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Tests
{
    public class MockLogService : ILogService
    {
        public Task LogAsync(ProbabilityCalculationDto dto, decimal result)
        {
            return Task.CompletedTask;
        }
    }
}