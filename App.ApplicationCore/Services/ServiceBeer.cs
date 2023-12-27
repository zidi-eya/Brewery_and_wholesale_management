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

        
       
    }
}
