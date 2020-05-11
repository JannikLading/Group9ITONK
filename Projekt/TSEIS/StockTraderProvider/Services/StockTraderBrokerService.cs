using StockTraderBroker.Models;
using StockTraderBroker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Services
{
    public class StockTraderBrokerService : IStockTraderBrokerService
    {

        private IStockTraderBrokerRepository _repo;

        public StockTraderBrokerService(IStockTraderBrokerRepository repo)
        {
            this._repo = repo;
        }

        public void AddStockTrade(StockTrade stockTrade)
        {
            _repo.AddStockTrade(stockTrade);
        }

        public void DeleteStockTrade(int id)
        {
            _repo.DeleteStockTrade(id);
        }

        public List<StockTrade> GetStockTrades()
        {
            return _repo.GetStockTrades();
        }

        public StockTrade UpdateBuyerOnStockTrade(int stockTradeId, int buyerId)
        {
            StockTrade stockTrade = _repo.GetById(stockTradeId);
            stockTrade.StockBuyerId = buyerId;
            _repo.UpdateStockTrade(stockTrade);
            return stockTrade; 
        }
    }
}
