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
            Stock vestas = new Stock { Name = "Vestas Wind System", Price = 584.60 };
            Stock danskeBank = new Stock { Name = "Danske Bank", Price = 72.70 };
            Stock carlsbergB = new Stock { Name = "Carlsberg B", Price = 810.20 };
            Stock mearskA = new Stock { Name = "A.P. Møller - Mærsk A", Price = 5930.00 };
            Stock mearskb = new Stock { Name = "A.P. Møller - Mærsk B", Price = 6380.00 };
            Stock novoNordisk = new Stock { Name = "Novo Nordisk", Price = 413.90 };
            Stocks.Add(vestas);
            Stocks.Add(danskeBank);
            Stocks.Add(carlsbergB);
            Stocks.Add(mearskA);
            Stocks.Add(mearskb);
            Stocks.Add(novoNordisk);

        }
    }
}
