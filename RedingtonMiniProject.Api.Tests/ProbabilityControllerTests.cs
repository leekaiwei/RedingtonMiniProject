using Microsoft.AspNetCore.Mvc;
using RedingtonMiniProject.Api.Controllers;
using RedingtonMiniProject.Api.Data;
using RedingtonMiniProject.Api.Models;
using Xunit;

namespace RedingtonMiniProject.Api.Tests
{
    public class ProbabilityControllerTests
    {
        [Theory]
        [InlineData(Database.CombinedWith, 0.25)]
        [InlineData(Database.Either, 0.75)]
        public async void Calculate_Outputs_Correct_Result(string probabilityFunction, decimal expectedResult)
        {
            var controller = new ProbabilityController();

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
    }
}