namespace RedingtonMiniProject.Api.Calculators
{
    public class EitherCalculator : ICalculator
    {
        public decimal Calculate(decimal probabilityOne, decimal probabilityTwo)
        {
            return probabilityOne + probabilityTwo - probabilityOne * probabilityTwo;
        }
    }
}