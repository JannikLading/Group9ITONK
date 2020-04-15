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
        public AppDbContext()
        {
            LoadDefaultData();
        }
        public DbSet<StockTransaction> Transactions{ get; set; }

        public void LoadDefaultData()
        {

        }
    }
}
