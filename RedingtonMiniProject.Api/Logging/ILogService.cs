using RedingtonMiniProject.Api.Models;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Logging
{
    public interface ILogService
    {
        Task LogAsync(ProbabilityCalculationDto dto, decimal result);
    }
}