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

            if (_dbContext.Stocks.Count() == 0)
                LoadDefaultData();
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
            catch (Exception)
            {
                //Error accured
            }
            return stocks;
        }

        private void LoadDefaultData()
        {
            Stock vestas = new Stock { Name = "Vestas Wind System", Price = 100.00 };
            Stock danskeBank = new Stock { Name = "Danske Bank", Price = 200.00 };
            Stock carlsbergB = new Stock { Name = "Carlsberg B", Price = 300.00 };
            Stock mearskA = new Stock { Name = "A.P. Møller - Mærsk A", Price = 400.00 };
            Stock mearskb = new Stock { Name = "A.P. Møller - Mærsk B", Price = 500.00 };
            Stock novoNordisk = new Stock { Name = "Novo Nordisk", Price = 600.00 };
            _dbContext.Stocks.Add(vestas);
            _dbContext.Stocks.Add(danskeBank);
            _dbContext.Stocks.Add(carlsbergB);
            _dbContext.Stocks.Add(mearskA);
            _dbContext.Stocks.Add(mearskb);
            _dbContext.Stocks.Add(novoNordisk);
            _dbContext.SaveChanges();

        }
    }
}
