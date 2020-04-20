using PublicShareOwnerControl.Database;
using PublicShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Repositories
{
    public class PublicShareOwnerRepository : IPublicShareOwnerRepository
    {
        private readonly AppDbContext _dbContext;

        PublicShareOwnerRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void AddStockTrader(StockTrader user)
        {
            if (GetStockTrader(user.Id) == null)
                _dbContext.StockTraders.Add(user);
        }

        public StockTrader GetStockTrader(int id)
        {
            return _dbContext.StockTraders.FirstOrDefault(u => u.Id == id);
        }

        public List<StockTrader> GetStockTraders()
        {
            return _dbContext.StockTraders.ToList();
        }

        public StockTrader UpdateStockTrader(StockTrader newStockTrader)
        {
            var oldStockTrader = _dbContext.StockTraders.FirstOrDefault(u => u.Id == newStockTrader.Id);
            if(oldStockTrader != null)
            {
                oldStockTrader = newStockTrader;
                _dbContext.SaveChangesAsync();
            }
            return oldStockTrader;
        }

        void loadData() {

            var stockShares1 = new Dictionary<int, int>();
            stockShares1.Add(1, 2);
            stockShares1.Add(2, 3);
            stockShares1.Add(3, 4);

            _dbContext.StockPortefolios.Add(new StockPortefolio()
            {
                StockShares = stockShares1,
                TotalAmount
            })
        }
    }
}
