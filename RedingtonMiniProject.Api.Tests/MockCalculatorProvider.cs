using RedingtonMiniProject.Api.Calculators;

namespace RedingtonMiniProject.Api.Tests
{
    public class MockCalculatorProvider : CalculatorProvider
    {
        public override ICalculator GetCalculator(string probabilityFunction)
        {
            return new MockCalculator();
        }
    }
}