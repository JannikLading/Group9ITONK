using PublicShareOwnerControl.Models;
using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradedShares.Models;

namespace PublicShareOwnerControl.Services
{
    public interface IPublicShareOwnerService
    {
        void AddUser(StockTrader stockTrader);
        void UpdateStockTrader(StockTrader stockTrader);
        StockTrader GetStockTrader(int userId);
        List<StockTrader> GetStockTraders();
        void DeleteUser();
        bool TransferStocks(StockTrade trade, Stock stock);
    }
}
