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

        public void AddStockUser(StockUser user)
        {
            if (GetStockUser(user.Id) == null)
                _dbContext.StockUsers.Add(user);
        }

        public StockUser GetStockUser(int id)
        {
            return _dbContext.StockUsers.FirstOrDefault(u => u.Id == id);
        }

        public List<StockUser> GetStockUsers()
        {
            return _dbContext.StockUsers.ToList();
        }

        public StockUser UpdateStockUser(StockUser newStockUser)
        {
            var oldStockUser = _dbContext.StockUsers.FirstOrDefault(u => u.Id == newStockUser.Id);
            if(oldStockUser != null)
            {
                oldStockUser = newStockUser;
                _dbContext.SaveChangesAsync();
            }
            return oldStockUser;
        }
    }
}
