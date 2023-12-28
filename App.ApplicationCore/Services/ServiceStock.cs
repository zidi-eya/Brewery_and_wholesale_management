using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class ServiceStock : Service<Stock>, IServiceStock
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceStock(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public Stock UpdateStock(Stock stock)
        {
            _unitOfWork.Repository<Stock>().Update(stock);
            _unitOfWork.Commit();
            return stock;
        }
    }
}
