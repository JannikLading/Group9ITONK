using Microsoft.EntityFrameworkCore;
using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            LoadDefaultData();
        }
        public DbSet<StockTrade> StockTrades { get; set; }

        public void LoadDefaultData()
        {

        }
    }
}