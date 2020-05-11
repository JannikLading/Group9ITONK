using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Repositories
{
    public interface IStockTraderBrokerRepository
    {
        void AddStockTrade(StockTrade stockTrade);
        void UpdateStockTrade(StockTrade stockTrade);
        List<StockTrade> GetStockTrades();
        StockTrade GetById(int id);
        void DeleteStockTrade(int id);
    }
}
