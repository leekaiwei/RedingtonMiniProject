namespace RedingtonMiniProject.Api.Calculators
{
    public class CombinedWithCalculator : ICalculator
    {
        public decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA * probabilityB;
        }
    }
}