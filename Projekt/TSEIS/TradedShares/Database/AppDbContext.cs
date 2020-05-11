using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TradedShares.Models;

namespace TradedShares.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            LoadDefaultData();
        }
        public DbSet<Stock> Stocks { get; set; }

        public void LoadDefaultData()
        {
            Stock vestas = new Stock { Name = "Vestas Wind System", Price = 100.00 };
            Stock danskeBank = new Stock { Name = "Danske Bank", Price = 200.00 };
            Stock carlsbergB = new Stock { Name = "Carlsberg B", Price = 300.00 };
            Stock mearskA = new Stock { Name = "A.P. Møller - Mærsk A", Price = 400.00};
            Stock mearskb = new Stock { Name = "A.P. Møller - Mærsk B", Price = 500.00 };
            Stock novoNordisk = new Stock { Name = "Novo Nordisk", Price = 600.00 };
            Stocks.Add(vestas);
            Stocks.Add(danskeBank);
            Stocks.Add(carlsbergB);
            Stocks.Add(mearskA);
            Stocks.Add(mearskb);
            Stocks.Add(novoNordisk);

        }
    }
}
