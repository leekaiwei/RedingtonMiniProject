using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Data;
using RedingtonMiniProject.Api.Models;
using RedingtonMiniProject.Api.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbabilityController : ControllerBase
    {
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

            var logs = new List<Log>
            {
                new Log
                {
                    Date = DateTime.UtcNow,
                    Type = dto.ProbabilityFunction,
                    ProbabilityOne = dto.ProbabilityOne,
                    ProbabilityTwo = dto.ProbabilityTwo,
                    Result = result,
                }
            };

            using (var writer = new StreamWriter("log.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                await csv.WriteRecordsAsync(logs);
            }

            return Ok(result);
        }
    }
}