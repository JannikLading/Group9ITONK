using StockTraderBroker.Database;
using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Repositories
{
    public class StockTraderBrokerRepository : IStockTraderBrokerRepository
    {
        private AppDbContext _dbContext;
        public StockTraderBrokerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStockTrade(StockTrade stockTrade)
        {
            if (stockTrade != null)
            {
                _dbContext.StockTrades.Add(stockTrade);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteStockTrade(int id)
        {
            _dbContext.StockTrades.Remove(_dbContext.StockTrades.Find(id));
            _dbContext.SaveChanges();
        }

        public StockTrade GetById(int id)
        {
            if (id != 0)
            {
                return _dbContext.StockTrades.Find(id);
            }
            return null;
        }

        public List<StockTrade> GetStockTrades()
        {
            var stocks = new List<StockTrade>();
            try
            {
                stocks = _dbContext.StockTrades.ToList();
            }
            catch (Exception e)
            {
                //Error accured
            }
            return stocks;
        }

        public void UpdateStockTrade(StockTrade stockTrade)
        {
            _dbContext.StockTrades.Update(stockTrade);
            _dbContext.SaveChanges();
        }
    }
}
