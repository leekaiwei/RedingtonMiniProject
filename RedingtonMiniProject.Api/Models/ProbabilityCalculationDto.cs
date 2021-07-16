using System.ComponentModel.DataAnnotations;

namespace RedingtonMiniProject.Api.Models
{
    public class ProbabilityCalculationDto
    {
        [Required]
        public string ProbabilityFunction { get; set; }

        [Range(0, 1)]
        public decimal ProbabilityA { get; set; }

        [Range(0, 1)]
        public decimal ProbabilityB { get; set; }
    }
}