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
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(s => new
            {
                s.WholesalerFK,
                s.BeerFK,
                s.StockId
            });
            builder.HasOne(s => s.Wholesaler).WithMany(s => s.Stocks).HasForeignKey(s => s.WholesalerFK);
            builder.HasOne(s=>s.Beer).WithMany(s=>s.Stocks).HasForeignKey(s=>s.BeerFK);

        }
    }
}
