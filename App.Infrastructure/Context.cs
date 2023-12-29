using App.ApplicationCore.Entities;
using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Wholesaler> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());

            // Add other configurations as needed...

            base.OnModelCreating(modelBuilder);

        }
    }
}
