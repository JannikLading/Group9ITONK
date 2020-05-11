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

        private void loadData() {

            var stockShares1 = new Dictionary<int, int>();
            stockShares1.Add(1, 2);
            stockShares1.Add(2, 3);
            stockShares1.Add(3, 4);

            int totalAmount = 0;
            int totalPrice = 0;
            foreach(var key in stockShares1.Keys)
            {
                int amount = 0;
                stockShares1.TryGetValue(key, out amount);
                totalAmount += amount;
                totalPrice += amount * key * 100;
            }

            _dbContext.StockPortefolios.Add(new StockPortefolio()
            {
                StockShares = stockShares1,
                TotalAmount = totalAmount,
                TotalPrice = totalPrice
            });

            var stockShares2 = new Dictionary<int, int>();
            stockShares2.Add(4, 1);
            stockShares2.Add(5, 2);
            stockShares2.Add(6, 3);

            totalAmount = 0;
            totalPrice = 0;
            foreach (var key in stockShares2.Keys)
            {
                int amount = 0;
                stockShares2.TryGetValue(key, out amount);
                totalAmount += amount;
                totalPrice += amount * key * 100;
            }

            _dbContext.StockPortefolios.Add(new StockPortefolio()
            {
                StockShares = stockShares2,
                TotalAmount = totalAmount,
                TotalPrice = totalPrice
            });

            var stockShares3 = new Dictionary<int, int>();
            stockShares3.Add(1, 2);
            stockShares3.Add(3, 3);
            stockShares3.Add(4, 2);
            stockShares3.Add(6, 1);

            totalAmount = 0;
            totalPrice = 0;
            foreach (var key in stockShares3.Keys)
            {
                int amount = 0;
                stockShares3.TryGetValue(key, out amount);
                totalAmount += amount;
                totalPrice += amount * key * 100;
            }

            _dbContext.StockPortefolios.Add(new StockPortefolio()
            {
                StockShares = stockShares3,
                TotalAmount = totalAmount,
                TotalPrice = totalPrice
            });

            var portfolios = _dbContext.StockPortefolios.ToList();
            _dbContext.StockTraders.Add(new StockTrader()
            {
                UserId = 1,
                Portefolio = portfolios[0],
            });
        }
    }
}
