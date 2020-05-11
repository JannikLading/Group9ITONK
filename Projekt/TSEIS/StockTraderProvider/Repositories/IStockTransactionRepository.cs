using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Repositories
{
    public interface IStockTransactionRepository
    {
        void addStockTransaction(StockTrade stockTransaction);
        StockTrade GetTransaction(int id);
    }
}
