using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Models
{
    public class StockTrade
    {
        [Key]
        public int Id { get; set; }
        public int TransferStockId { get; set; }
        public int StockAmount { get; set; }
        public double StockPrice { get; set; }
        public int StockBuyerId { get; set; }
        public int StockSellerId { get; set; }
        public double TaxAmount { get; set; }
        public bool TransactionComplete { get; set; }
        public bool StockTransferComplete { get; set; }
    }
}