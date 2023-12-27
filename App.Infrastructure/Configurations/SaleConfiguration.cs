using App.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s=>new{
                s.BeerFK,
                s.WholesalerFK,
                s.SaleId
            });
            builder.HasOne(s => s.Wholesaler).WithMany(w => w.Sales).HasForeignKey(s=>s.WholesalerFK);
            builder.HasOne(s=>s.Beer).WithMany(b=>b.Sales).HasForeignKey(b=>b.BeerFK);
        }
    }
}
