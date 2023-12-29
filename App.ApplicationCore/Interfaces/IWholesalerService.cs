using App.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface IWholesalerService : IService<Wholesaler>
    {
        QuoteResult RequestQuote(int wholesalerId, Dictionary<int, int> beerQuantities);

    }
}
