using CsvHelper;
using CsvHelper.Configuration;
using RedingtonMiniProject.Api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace RedingtonMiniProject.Api.Logging
{
    public class LogService : ILogService
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

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using var stream = File.Open("log.csv", FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, config);
            await csv.WriteRecordsAsync(logs);
        }
    }
}