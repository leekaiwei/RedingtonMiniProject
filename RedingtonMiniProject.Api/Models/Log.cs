using System;

namespace RedingtonMiniProject.Api.Models
{
    public class Log
    {
        public DateTime Date { get; set; }

        public string Type { get; set; }

        public decimal ProbabilityOne { get; set; }

        public decimal ProbabilityTwo { get; set; }

        public decimal Result { get; set; }
    }
}