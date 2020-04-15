using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradedShares.Database;
using TradedShares.Models;

namespace TradedShares.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _dbContext;

        public StockRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddStock(Stock stock)
        {
            if (stock != null)
            {
                _dbContext.Stocks.Add(stock);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteStock(int id)
        {
            _dbContext.Stocks.Remove(_dbContext.Stocks.Find(id));
            _dbContext.SaveChanges();
        }

        public Stock GetById(int id)
        {
            if (id != 0)
            {
                return _dbContext.Stocks.Find(id);
            }
            return null;
        }

        public List<Stock> GetStocks()
        {
            var stocks = new List<Stock>();
            try
            {
                stocks = _dbContext.Stocks.ToList();
            }
            catch (Exception e)
            {
                //Error accured
            }
            return stocks;
        }
    }
}
