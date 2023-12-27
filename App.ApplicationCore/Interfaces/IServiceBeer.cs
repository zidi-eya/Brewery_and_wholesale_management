using App.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface IServiceBeer : IService<Beer>
    {
        IList<Beer> GetAllBeerbyBrewery(int breweryId);
        public void addBeerByBrewery(Beer beer, int breweryId);
        void DeleteBeer(int beerId);


    }
}
