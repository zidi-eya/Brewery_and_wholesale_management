using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class ServiceBeer : Service<Beer>, IServiceBeer
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBeer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       

        public IList<Beer> GetAllBeerbyBrewery(int breweryId)
        {
            Brewery brewery = _unitOfWork.Repository<Brewery>().GetById(breweryId);


            if (brewery == null || brewery.BreweryId == 0)
            {
                throw new ArgumentException("Invalid brewery entity.");
            }
            return _unitOfWork.Repository<Beer>().Find(beer => beer.Brewery.BreweryId == breweryId).ToList();
        }

        public void addBeerByBrewery(Beer beer, int breweryId)
        {
            Brewery brewery = _unitOfWork.Repository<Brewery>().GetById(breweryId);
            beer.Brewery = brewery;

            _unitOfWork.Repository<Beer>().Add(beer);
            _unitOfWork.Commit();
        }
        public void DeleteBeer(int BeerId)
        {
            var beer = _unitOfWork.Repository<Beer>().GetById(BeerId);
            if (beer == null)
            {
                throw new ArgumentException("Beer not found.", nameof(BeerId));
            }

            _unitOfWork.Repository<Beer>().Delete(beer);
            _unitOfWork.Commit();
        }

        public Sale AddBeerSale(int beerId, int wholesalerId)
        {
            var beer = _unitOfWork.Repository<Beer>().GetById(beerId);
            if (beer == null)
            {
                throw new ArgumentException("Beer not found.", nameof(beerId));
            }

            var wholesaler = _unitOfWork.Repository<Wholesaler>().GetById(wholesalerId);
            if (wholesaler == null)
            {
                throw new ArgumentException("Wholesaler not found.", nameof(wholesalerId));
            }

            var sale = new Sale
            {
                BeerFK = beerId,
                WholesalerFK = wholesalerId
            };
            sale.Beer = beer;
            sale.Wholesaler = wholesaler;
            _unitOfWork.Repository<Sale>().Add(sale);
            _unitOfWork.Commit();

            return sale;
        }

    }
}
