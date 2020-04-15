using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradedShares.Models;

namespace StockTraderBroker.Models
{
    public class StockTransaction
    {
        int id;
        Stock transactionStock;
        int transferAmount;
        double transferPrice;
        StockUser stockByuer;
        StockUser stockSeller;
        bool approved;
    }
}
