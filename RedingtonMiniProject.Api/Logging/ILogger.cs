using RedingtonMiniProject.Api.Models;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Logging
{
    public interface ILogger
    {
        Task LogAsync(ProbabilityCalculationDto dto, decimal result);
    }
}