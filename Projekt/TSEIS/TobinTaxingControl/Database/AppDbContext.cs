using Microsoft.EntityFrameworkCore;
using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobinTaxingControl.Models;

namespace TobinTaxingControl.Database
{
    public class AppDbContext: DbContext 
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            LoadDefaultData();
        }
        public DbSet<TaxRegistration> TaxRegistrations { get; set; }

        public void LoadDefaultData()
        {
            TaxRegistrations.Add(new TaxRegistration
                {
                Id = 0, 
                Approved = false, 
                TaxAmount = 1000 
            });
        }
    }
}
