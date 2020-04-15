using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TobinTaxingControl.Models
{
    public class TaxRegistration
    {
        [Key]
        int id { get; set; }
        StockTransaction transaction { get; set; }
        double taxAmount { get; set; }
        bool approved { get; set; }

    }
}
