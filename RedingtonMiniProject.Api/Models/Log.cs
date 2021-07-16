using System;

namespace RedingtonMiniProject.Api.Models
{
    public class Log
    {
        public DateTime Date { get; set; }

        public string Type { get; set; }

        public decimal ProbabilityA { get; set; }

        public decimal ProbabilityB { get; set; }

        public decimal Result { get; set; }
    }
}