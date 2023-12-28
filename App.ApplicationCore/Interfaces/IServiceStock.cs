using App.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface IServiceStock : IService<Stock>
    {
        public Stock UpdateStock(Stock stock);

    }
}
