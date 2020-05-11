using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Models
{
    public class SellerDto
    {
        public int TransferStockId { get; set; }
        public int StockAmount { get; set; }
        public double StockPrice { get; set; }
        public int StockSellerId { get; set; }
    }
}
