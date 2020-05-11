using StockTraderBroker.Database;
using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderBroker.Repositories
{
    public class StockTransactionRepository : IStockTransactionRepository
    {
        private AppDbContext _dbContext;
        public StockTransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void addStockTransaction(StockTrade stockTransaction)
        {
            _dbContext.Transactions.Add(stockTransaction);
        }

        public StockTrade GetTransaction(int id)
        {
            return _dbContext.Transactions.Find(id);
        }
    }
}
