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
        public void addStockTransaction(StockTransaction stockTransaction)
        {
            throw new NotImplementedException();
        }

        public StockTransaction GetTransaction(int id)
        {
            throw new NotImplementedException();
        }
    }
}
