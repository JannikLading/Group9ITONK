using PublicShareOwnerControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Repositories
{
    interface IPublicShareOwnerRepository
    {
        void AddStockTrader(StockTrader user);
        List<StockTrader> GetStockTraders();
        StockTrader GetStockTrader(int id);
        StockTrader UpdateStockTrader(StockTrader newStockUser);
    }
}
