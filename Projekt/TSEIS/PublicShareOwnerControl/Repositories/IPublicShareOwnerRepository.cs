using PublicShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Repositories
{
    interface IPublicShareOwnerRepository
    {
        void AddStockUser(StockUser user);
        List<StockUser> GetStockUsers();
        StockUser GetStockUser(int id);
        StockUser UpdateStockUser(StockUser newStockUser);
    }
}
