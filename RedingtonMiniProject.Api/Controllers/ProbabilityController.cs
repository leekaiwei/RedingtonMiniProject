using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Data;
using RedingtonMiniProject.Api.Logging;
using RedingtonMiniProject.Api.Models;
using RedingtonMiniProject.Api.Validators;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbabilityController : ControllerBase
    {
        private readonly ILogger _logger;

        public ProbabilityController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Calculate([FromQuery] ProbabilityCalculationDto dto)
        {
            if (!Validator.ValidateProbabilityFunction(dto.ProbabilityFunction))
            {
                return BadRequest("Invalid probability function.");
            }

            if (dto.ProbabilityFunction == Database.CombinedWith)
            {
                return Ok(dto.ProbabilityOne * dto.ProbabilityTwo);
            }

            var result = dto.ProbabilityOne + dto.ProbabilityTwo - dto.ProbabilityOne * dto.ProbabilityTwo;

            await _logger.LogAsync(dto, result);

            return Ok(result);
        }
    }
}