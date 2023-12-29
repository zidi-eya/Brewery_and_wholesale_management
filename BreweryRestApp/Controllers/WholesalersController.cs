using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BreweryRestApp.Controllers
{
    [ApiController]
    [Route("api/wholesalers")]
    public class WholesalersController : Controller
    {
        private readonly IWholesalerService _WholesalerService;
        public WholesalersController(IWholesalerService wholesalerService)
        {
            _WholesalerService = wholesalerService;
        }

        [HttpPost("{wholesalerId}/quote")]
        public ActionResult<QuoteResult> GetQuote(int wholesalerId, [FromBody] Dictionary<int, int> beerQuantities)
        {
            try
            {
                var quoteResult = _WholesalerService.RequestQuote(wholesalerId, beerQuantities);
                return Ok(quoteResult);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }




    }
}
