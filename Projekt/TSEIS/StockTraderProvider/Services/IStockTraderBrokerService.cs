using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Services
{
    public interface IStockTraderBrokerService
    {
        void AddStockTrade(StockTrade stockTrade);
        StockTrade UpdateBuyerOnStockTrade(int stockTradeId, int buyerId);
        List<StockTrade> GetStockTrades();
        void DeleteStockTrade(int id);
    }
}