using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class WholesalerService : Service<Wholesaler>, IWholesalerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WholesalerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public QuoteResult RequestQuote(int wholesalerId, Dictionary<int, int> beerQuantities)
        {
            if (beerQuantities == null || !beerQuantities.Any())
                throw new ArgumentException("The order cannot be empty.");

            var wholesaler = _unitOfWork.Repository<Wholesaler>().GetById(wholesalerId);
            if (wholesaler == null)
                throw new ArgumentException("The wholesaler dosen't exist.");

            if (beerQuantities.GroupBy(bq => bq.Key).Any(g => g.Count() > 1))
                throw new ArgumentException("There can't be any duplicates in the order.");

            var quoteResult = new QuoteResult();
            float totalPrice = 0;

            foreach (var bq in beerQuantities)
            {
                var beerStock = wholesaler.Stocks.FirstOrDefault(s => s.BeerFK == bq.Key);
                if (beerStock == null || beerStock.Quantity < bq.Value)
                    throw new ArgumentException($"The beer with ID {bq.Key} does not  sold by the wholesaler and cannot exceed the wholesaler's stock.");

                 double basePrice = beerStock.Beer.Price * bq.Value;
                float discountMultiplier = 1.0f;

                if (bq.Value > 20)
                    discountMultiplier = 0.8f;
                else if (bq.Value > 10)
                    discountMultiplier = 0.9f;

                 totalPrice += (float)basePrice * discountMultiplier;
            }

            quoteResult.TotalPrice = totalPrice;
            quoteResult.Summary = $"The total price for the quote is: {totalPrice:C}";

            return quoteResult;
        }

    }
}
