using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Constants;
using RedingtonMiniProject.Api.Controllers;
using Xunit;

namespace RedingtonMiniProject.Api.Tests
{
    public class ProbabilityControllerTests
    {
        [Theory]
        [InlineData(ProbabilityFunctionEnum.CombinedWith, 0.25)]
        [InlineData(ProbabilityFunctionEnum.Either, 0.75)]
        public void Calculate_Outputs_Correct_Result(ProbabilityFunctionEnum probabilityFunction, decimal expectedResult)
        {
            var controller = new ProbabilityController();

            var response = controller.Calculate(0.5m, 0.5m, probabilityFunction);
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(expectedResult, result.Value);
        }
    }
}