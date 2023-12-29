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
        private object _ServiceBeer;

                

        [Fact]
        public void GetAllBeerByBrewery_ReturnsOkResultWithBeers_WhenGivenValidBreweryId()
        {
            // Arrange
            var mockBeerService = new Mock<IServiceBeer>();
            var controller = new BeerController(mockBeerService.Object);
            var brewery = new Brewery
            {
                // Initialisez les propriétés nécessaires de Brewery ici
                BreweryId = 1,
                Name = "Brasserie Exemple",
                // D'autres propriétés selon votre modèle
            }; var fakeBeers = new List<Beer>
        {
            new Beer { BeerId = 3, Name = "leffeblond", AlcoholContent = 10, Brewery = brewery}
        };

            mockBeerService.Setup(service => service.GetAllBeerbyBrewery(brewery.BreweryId))
                .Returns(fakeBeers);

            // Act
            var result = controller.GetAllBeerByBrewery(brewery.BreweryId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedBeers = okResult.Value.Should().BeAssignableTo<List<Beer>>().Subject;

            returnedBeers.Should().HaveCount(fakeBeers.Count);
            returnedBeers.Should().BeEquivalentTo(fakeBeers);

            mockBeerService.Verify(service => service.GetAllBeerbyBrewery(brewery.BreweryId), Times.Once);
        }
        
        [Fact]
        public void GetAllBeerByBrewery_ThrowsNotImplementedException_WhenServiceMethodNotImplemented()
        {
            // Arrange
            var mockBeerService = new Mock<IServiceBeer>();
            var controller = new BeerController(mockBeerService.Object);
            var breweryId = 1;

            mockBeerService.Setup(service => service.GetAllBeerbyBrewery(breweryId))
                .Throws(new System.NotImplementedException());

            // Act & Assert
            Assert.Throws<System.NotImplementedException>(() => controller.GetAllBeerByBrewery(breweryId));
        }


    }
}
