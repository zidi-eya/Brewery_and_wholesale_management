
using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;


namespace BreweryRestApp.Controllers
{
    [Route("beer/[controller]")]
    [ApiController]
    public class StockController
    {



        private readonly IServiceStock _serviceStock;

        public StockController(IServiceStock serviceStock)
        {
            _serviceStock = serviceStock;
        }

        [HttpPut("updatestock")]
        public ActionResult<Stock> updatestock(Stock stock)
        {
            // Assuming you have a way to get a Brewery entity by ID,
            // perhaps using another service or repository method.
            return _serviceStock.UpdateStock(stock);
        }

    }
}
