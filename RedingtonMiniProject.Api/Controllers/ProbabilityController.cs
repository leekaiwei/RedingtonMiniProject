using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Calculators;
using RedingtonMiniProject.Api.Logging;
using RedingtonMiniProject.Api.Models;
using RedingtonMiniProject.Api.Validators;
using System;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbabilityController : ControllerBase
    {
        private readonly ILogService _logger;

        public ProbabilityController(ILogService logger)
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

            var calculator = CalculatorProvider.GetCalculator(dto.ProbabilityFunction);
            if (calculator == null)
            {
                throw new NullReferenceException($"Calculator {dto.ProbabilityFunction} not found");
            }

            var result = calculator.Calculate(dto.ProbabilityOne, dto.ProbabilityTwo);

            await _logger.LogAsync(dto, result);

            return Ok(result);
        }
    }
}