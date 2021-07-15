using CsvHelper;
using RedingtonMiniProject.Api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Logging
{
    public class Logger : ILogger
    {
        public async Task LogAsync(ProbabilityCalculationDto dto, decimal result)
        {
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
        }
    }
}