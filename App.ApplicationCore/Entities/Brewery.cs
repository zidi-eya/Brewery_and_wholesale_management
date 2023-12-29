using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Entities
{
    public class Brewery
    {
        [Key]

        public int BreweryId { get; set; }

        public string Name { get; set; }
        // Navigation property for related Beers

        public virtual ICollection<Wholesaler>? Beers { get; set; }

        public static implicit operator Brewery(int v)
        {
            throw new NotImplementedException();
        }
    }
}
