using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Controllers;
using RedingtonMiniProject.Api.Logging;
using RedingtonMiniProject.Api.Models;
using Xunit;

namespace RedingtonMiniProject.Api.Tests
{
    public class ProbabilityControllerTests
    {
        private readonly ILogService _mockLogService;

        public ProbabilityControllerTests()
        {
            _mockLogService = new MockLogService();
        }

        [Theory]
        [InlineData(Data.ProbablityTypes.CombinedWith, 0.25)]
        [InlineData(Data.ProbablityTypes.Either, 0.75)]
        public async void Calculate_Outputs_Correct_Result(string probabilityFunction, decimal expectedResult)
        {
            var controller = new ProbabilityController(_mockLogService);

            var dto = new ProbabilityCalculationDto
            {
                ProbabilityFunction = probabilityFunction,
                ProbabilityOne = 0.5m,
                ProbabilityTwo = 0.5m,
            };

            var response = await controller.Calculate(dto);
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async void Calculate_InvalidProbabilityFunction_Returns_BadRequest()
        {
            var controller = new ProbabilityController(_mockLogService);

            var dto = new ProbabilityCalculationDto
            {
                ProbabilityFunction = "invalid",
                ProbabilityOne = 0.5m,
                ProbabilityTwo = 0.5m,
            };

            var response = await controller.Calculate(dto);
            var result = Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}