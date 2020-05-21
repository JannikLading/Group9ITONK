using Newtonsoft.Json;
using PublicShareOwnerControl.Database;
using PublicShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace PublicShareOwnerControl.Repositories
{
    public class PublicShareOwnerRepository : IPublicShareOwnerRepository
    {
        private readonly AppDbContext _dbContext;

        public PublicShareOwnerRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            if(_dbContext.StockTraders.Count() == 0 && _dbContext.StockPortefolios.Count() == 0) 
                loadData();
        }

        public void AddStockTrader(StockTrader user)
        {
            if (GetStockTrader(user.Id) == null)
                _dbContext.StockTraders.Add(user);
        }

        public StockTrader GetStockTrader(int? id)
        {
            return _dbContext.StockTraders.Include(t=>t.Portefolio).FirstOrDefault(u => u.UserId == id);
        }

        public List<StockTrader> GetStockTraders()
        {
            return _dbContext.StockTraders.Include(x=>x.Portefolio).ToList();
        }

        public StockTrader UpdateStockTrader(StockTrader newStockTrader)
        {
            var oldStockTrader = _dbContext.StockTraders.FirstOrDefault(u => u.Id == newStockTrader.Id);
            if(oldStockTrader != null)
            {
                oldStockTrader = newStockTrader;
                _dbContext.SaveChanges();
            }
            return oldStockTrader;
        }

        private void loadData() {

            var stockShares1 = new List<KeyValuePair<int, int>>();
            stockShares1.Add(new KeyValuePair<int, int>(1,2));
            stockShares1.Add(new KeyValuePair<int, int>(2,3));
            stockShares1.Add(new KeyValuePair<int, int>(3, 4));

            int totalAmount = 0;
            int totalPrice = 0;
            foreach(var stockShare in stockShares1)
            {
                int amount = stockShare.Value;
                totalAmount += amount;
                totalPrice += amount * stockShare.Key * 100;
            }

            var portfolio1 = new StockPortefolio()
            {
                StockShares = JsonConvert.SerializeObject(stockShares1),
                TotalAmount = totalAmount,
                TotalPrice = totalPrice
            };

            _dbContext.StockPortefolios.Add(portfolio1);

            var stockShares2 = new List<KeyValuePair<int, int>>();
            stockShares2.Add(new KeyValuePair<int, int>(4, 1));
            stockShares2.Add(new KeyValuePair<int, int>(5, 2));
            stockShares2.Add(new KeyValuePair<int, int>(6, 3));
            
            totalAmount = 0;
            totalPrice = 0;
            foreach (var stockShare in stockShares2)
            {
                int amount = stockShare.Value;
                totalAmount += amount;
                totalPrice += amount * stockShare.Key * 100;
            }

            var portfolio2 = new StockPortefolio()
            {
                StockShares = JsonConvert.SerializeObject(stockShares2),
                TotalAmount = totalAmount,
                TotalPrice = totalPrice
            };
            _dbContext.StockPortefolios.Add(portfolio2);

            var stockShares3 = new List<KeyValuePair<int, int>>();
            stockShares3.Add(new KeyValuePair<int, int>(1,2));
            stockShares3.Add(new KeyValuePair<int, int>(3,3));
            stockShares3.Add(new KeyValuePair<int, int>(4,2));
            stockShares3.Add(new KeyValuePair<int, int>(6,1));

            totalAmount = 0;
            totalPrice = 0;
            foreach (var stockShare in stockShares3)
            {
                int amount = stockShare.Value;
                totalAmount += amount;
                totalPrice += amount * stockShare.Key * 100;
            }

            var portfolio3 = new StockPortefolio()
            {
                StockShares = JsonConvert.SerializeObject(stockShares3),
                TotalAmount = totalAmount,
                TotalPrice = totalPrice
            };
            _dbContext.StockPortefolios.Add(portfolio3);

            _dbContext.StockTraders.Add(new StockTrader()
            {
                UserId = 1,
                Portefolio = portfolio1,
            });

            _dbContext.StockTraders.Add(new StockTrader()
            {
                UserId = 2,
                Portefolio = portfolio2,
            });

            _dbContext.StockTraders.Add(new StockTrader()
            {
                UserId = 3,
                Portefolio = portfolio3,
            });
            _dbContext.SaveChanges();
        }
    }
}
