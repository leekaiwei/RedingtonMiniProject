namespace RedingtonMiniProject.Api.Calculators
{
    public interface ICalculator
    {
        decimal Calculate(decimal probabilityA, decimal probabilityB);
    }
}