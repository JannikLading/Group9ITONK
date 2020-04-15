using Microsoft.EntityFrameworkCore;
using PublicShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradedShares.Models;

namespace PublicShareOwnerControl.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            LoadDefaultData();
        }
        public DbSet<StockUser> StockUsers { get; set; }
        public DbSet<StockPortefolio> StockPortefolios{ get; set; }
        public DbSet<Stock> Stocks { get; set; }


        public void LoadDefaultData()
        {

        }
    }
}
