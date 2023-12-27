using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.ApplicationCore.Entities
{
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }
        public string Name { get; set; }
        public float AlcoholContent { get; set; }
        public float Price { get; set; }

      

        // Navigation property for Brewery
        public virtual Brewery? Brewery { get; set; }

        // Navigation properties for related entities
        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }



    }



}
