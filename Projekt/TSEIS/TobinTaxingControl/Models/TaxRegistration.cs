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
        public int Id { get; set; }
        public int StockTransactionId { get; set; }
        public double TaxAmount { get; set; }
        public bool Approved { get; set; }

    }
}
