using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using BreweryRestApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryUnitTest.ControllersTest
{
    public class SalesControllerUnitTest
    {
        private readonly Mock<IServiceBeer> _mockBeerService;
        private readonly BeerController _controller;



        public SalesControllerUnitTest()
        {
            _mockBeerService = new Mock<IServiceBeer>();
            _controller = new BeerController(_mockBeerService.Object);
        }


       


        [Fact]
        public void AddSale_ReturnsNotFound_WhenArgumentExceptionIsThrown()
        {
            // Arrange
            var sale = new Sale { BeerFK = 1, WholesalerFK = 1 };
            var exceptionMessage = "Invalid sale data";

            _mockBeerService.Setup(service => service.AddBeerSale(sale.BeerFK, sale.WholesalerFK))
                .Throws(new ArgumentException(exceptionMessage));

            // Act
            var actionResult = _controller.AddSale(sale);

            // Assert
            var notFoundResult = actionResult.Result.Should().BeOfType<NotFoundObjectResult>().Subject;

            notFoundResult.Value.Should().Be(exceptionMessage);
        }



        [Fact]
        public void AddSale_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var sale = new Sale { BeerFK = 1, WholesalerFK = 1 };
            var exceptionMessage = "An error occurred";

            _mockBeerService.Setup(service => service.AddBeerSale(sale.BeerFK, sale.WholesalerFK))
                .Throws(new Exception(exceptionMessage));

            // Act
            var actionResult = _controller.AddSale(sale);

            // Assert
            var badRequestResult = actionResult.Result.Should().BeOfType<BadRequestObjectResult>().Subject;

            badRequestResult.Value.Should().Be(exceptionMessage);

        }

    }
}
