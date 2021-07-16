using RedingtonMiniProject.Api.Calculators;
using Xunit;

namespace RedingtonMiniProject.Api.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.13, 0.96, 0.1248)]
        [InlineData(0.74, 0.38, 0.2812)]
        public void CombinedWith_Calculate_Returns_Correct_Value(decimal probabilityA, decimal probabilityB, decimal expectedResult)
        {
            var calculator = new CombinedWithCalculator();

            var result = calculator.Calculate(probabilityA, probabilityB);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.13, 0.96, 0.9652)]
        [InlineData(0.74, 0.38, 0.8388)]
        public void Either_Calculate_Returns_Correct_Value(decimal probabilityA, decimal probabilityB, decimal expectedResult)
        {
            var calculator = new EitherCalculator();

            var result = calculator.Calculate(probabilityA, probabilityB);

            Assert.Equal(expectedResult, result);
        }
    }
}