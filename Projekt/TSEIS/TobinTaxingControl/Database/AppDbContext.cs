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
        public AppDbContext()
        {
            LoadDefaultData();
        }
        public DbSet<TaxRegistration> TaxRegistrations { get; set; }

        public void LoadDefaultData()
        {
            
        }
    }
}
