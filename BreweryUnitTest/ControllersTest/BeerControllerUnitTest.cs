using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using BreweryRestApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryUnitTest.ControllersTest
{
    public  class BeerControllerUnitTest
    {
        [Fact]
        public void GetAllBeerByBrewery_ReturnsOkResultWithBeers_WhenGivenValidBreweryId()
        {
            // Arrange
            var mockBeerService = new Mock<IServiceBeer>();
            var controller = new BeerController(mockBeerService.Object);
            var breweryId = 1; // Utilisez un ID valide pour la brasserie
            var fakeBeers = new List<Beer>
        {
            new Beer { BeerId = 2, Name = "absolut", AlcoholContent = 30 , Brewery = 1},
            new Beer { BeerId = 3, Name = "leffeblond", AlcoholContent = 10, Brewery = 1}
        };

            mockBeerService.Setup(service => service.GetAllBeerbyBrewery(breweryId))
                .Returns(fakeBeers);

            // Act
            var result = controller.GetAllBeerByBrewery(breweryId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedBeers = okResult.Value.Should().BeAssignableTo<List<Beer>>().Subject;

            returnedBeers.Should().HaveCount(fakeBeers.Count);
            returnedBeers.Should().BeEquivalentTo(fakeBeers);

            mockBeerService.Verify(service => service.GetAllBeerbyBrewery(breweryId), Times.Once);
        }

    }
}
