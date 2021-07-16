using RedingtonMiniProject.Api.Calculators;

namespace RedingtonMiniProject.Api.Tests
{
    public class MockCalculator : ICalculator
    {
        public decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return default;
        }
    }
}