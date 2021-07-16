namespace RedingtonMiniProject.Api.Calculators
{
    public class EitherCalculator : ICalculator
    {
        public decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA + probabilityB - probabilityA * probabilityB;
        }
    }
}