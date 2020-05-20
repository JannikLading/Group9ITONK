using Microsoft.EntityFrameworkCore;
using PublicShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<StockTrader> StockTraders { get; set; }
        public DbSet<StockPortefolio> StockPortefolios { get; set; }

        public void LoadDefaultData()
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockTrader>().HasKey(x => x.Id);
            modelBuilder.Entity<StockTrader>().HasOne(x => x.Portefolio).WithOne();

        }
    }
}
