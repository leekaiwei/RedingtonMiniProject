using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Controllers;
using RedingtonMiniProject.Api.Logging;
using RedingtonMiniProject.Api.Models;
using Xunit;

namespace RedingtonMiniProject.Api.Tests
{
    public class ProbabilityControllerTests
    {
        private readonly MockCalculatorProvider _mockCalculatorProvider;
        private readonly ILogService _mockLogService;

        public ProbabilityControllerTests()
        {
            _mockCalculatorProvider = new MockCalculatorProvider();
            _mockLogService = new MockLogService();
        }

        [Theory]
        [InlineData(Data.ProbablityTypes.CombinedWith)]
        [InlineData(Data.ProbablityTypes.Either)]
        public async void Calculate_Returns_Ok(string probabilityFunction)
        {
            var controller = new ProbabilityController(_mockCalculatorProvider,_mockLogService);

            var dto = new ProbabilityCalculationDto
            {
                ProbabilityFunction = probabilityFunction,
                ProbabilityA = 0.5m,
                ProbabilityB = 0.5m,
            };

            var response = await controller.Calculate(dto);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void Calculate_Returns_BadRequest()
        {
            var controller = new ProbabilityController(_mockCalculatorProvider, _mockLogService);

            var dto = new ProbabilityCalculationDto
            {
                ProbabilityFunction = "invalid",
                ProbabilityA = 0.5m,
                ProbabilityB = 0.5m,
            };

            var response = await controller.Calculate(dto);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}