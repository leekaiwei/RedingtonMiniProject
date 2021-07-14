using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Constants;

namespace RedingtonMiniProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbabilityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Calculate(decimal probabilityOne, decimal probabilityTwo, ProbabilityFunctionEnum probabilityFunction)
        {
            if (!ValidateProbability(probabilityOne) || !ValidateProbability(probabilityTwo))
            {
                return BadRequest("Probabilities cannot be less than 0 or greater than 1.");
            }

            if (probabilityFunction == ProbabilityFunctionEnum.CombinedWith)
            {
                return Ok(probabilityOne * probabilityTwo);
            }

            var result = probabilityOne + probabilityTwo - probabilityOne * probabilityTwo;

            return Ok(result);
        }

        private static bool ValidateProbability(decimal probability)
        {
            if (probability < 0 || probability > 1)
            {
                return false;
            }

            return true;
        }
    }
}