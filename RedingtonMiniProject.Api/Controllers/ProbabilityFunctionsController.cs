using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Data;

namespace RedingtonMiniProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProbabilityFunctionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ProbablityTypes.ProbabilityFunctions);
        }
    }
}