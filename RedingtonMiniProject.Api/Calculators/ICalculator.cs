namespace RedingtonMiniProject.Api.Calculators
{
    public interface ICalculator
    {
        decimal Calculate(decimal probabilityOne, decimal probabilityTwo);
    }
}