

using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace BreweryRestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : Controller
    {
        private readonly IServiceBeer _beerService;

        public BeerController(IServiceBeer beerService)
        {
            _beerService = beerService;
        }


        [HttpGet("ByBrewery/{breweryId}")]
        public ActionResult<List<Beer>> GetAllBeerByBrewery(int breweryId)
        {
            // Assuming you have a way to get a Brewery entity by ID,
            // perhaps using another service or repository method.


            var beers = _beerService.GetAllBeerbyBrewery(breweryId);
            return Ok(beers);
        }


        [HttpPost("AddBeer/{breweryId}")]
        public void addBeerByBrewery(Beer beer, int breweryId)
        {
            _beerService.addBeerByBrewery(beer, breweryId);
        }




        [HttpDelete("{BeerId}")]
        public IActionResult DeleteBeer(int BeerId)
        {
            try
            {
                _beerService.DeleteBeer(BeerId);
                return NoContent(); // 204 No Content is typically returned for successful delete requests
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // 404 Not Found if the beer doesn't exist
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return BadRequest(ex.Message); // 400 Bad Request for other types of exceptions
            }
        }
        [HttpPost("AddSale")]
        public ActionResult<Sale> AddSale(Sale sale)
        {
            try
            {
                var newSale = _beerService.AddBeerSale(sale.BeerFK, sale.WholesalerFK);
                return newSale;
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return BadRequest(ex.Message);
            }
        }

    }
}


