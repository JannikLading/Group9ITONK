using System.Collections.Generic;
using TradedShares.Models;

namespace TradedShares.Repositories
{
    public interface IStockRepository
    {
        void AddStock(Stock stock);
        List<Stock> GetStocks();
        Stock GetById(int id);
        void DeleteStock(int id);
    }
}
