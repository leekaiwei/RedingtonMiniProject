namespace RedingtonMiniProject.Api.Calculators
{
    public class CombinedWithCalculator : ICalculator
    {
        public decimal Calculate(decimal probabilityOne, decimal probabilityTwo)
        {
            return probabilityOne * probabilityTwo;
        }
    }
}