using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Models
{
    public class StockTransaction
    {
        [Key]
        public int Id { get; set; }
        //Stock transactionStock;
        public int TransferAmount { get; set; }
        public double TransferPrice { get; set; }
        //StockUser stockByuer;
        //StockUser stockSeller;
        public double TaxAmount { get; set; }
        public bool Approved { get; set; }
    }
}
