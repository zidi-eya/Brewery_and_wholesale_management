using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public int Quantity { get; set; }

        // Foreign keys
        public int BeerFK { get; set; }
        public int WholesalerFK { get; set; }

        // Navigation properties
        public virtual Beer Beer { get; set; }
        public virtual Wholesaler? Wholesaler { get; set; }
    }
}
