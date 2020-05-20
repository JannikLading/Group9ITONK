using Microsoft.Extensions.Logging;
using PublicShareOwnerControl.Models;
using PublicShareOwnerControl.Repositories;
using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradedShares.Models;

namespace PublicShareOwnerControl.Services
{
    public class PublicShareOwnerService : IPublicShareOwnerService
    {
        private ILogger<PublicShareOwnerService> _logger;
        private IPublicShareOwnerRepository _publicShareOwnerRepository;

        PublicShareOwnerService(ILogger<PublicShareOwnerService> logger, IPublicShareOwnerRepository publicShareOwnerRepository)
        {
            _logger = logger;
            _publicShareOwnerRepository = publicShareOwnerRepository;
        }

        public void AddUser(StockTrader stockUser)
        {
            _publicShareOwnerRepository.AddStockTrader(stockUser);
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public StockTrader GetStockTrader(int userId)
        {
            return _publicShareOwnerRepository.GetStockTrader(userId);
        }
        public List<StockTrader> GetStockTraders()
        {
            return _publicShareOwnerRepository.GetStockTraders();
        }

        public void UpdateStockTrader(StockTrader stockTrader)
        {
            _publicShareOwnerRepository.UpdateStockTrader(stockTrader);
        }

        public bool TransferStocks(StockTrade trade, Stock stock)
        {
            var transferComplete = false;

            if (trade.TransferStockId > 0 && trade.TransferStockId == stock.Id)
            {
                var seller = _publicShareOwnerRepository.GetStockTrader(trade.StockSellerId);
                var buyer = _publicShareOwnerRepository.GetStockTrader(trade.StockBuyerId);
                if(seller != null && buyer != null)
                {
                    var index = seller.Portefolio.StockShares.FindIndex(x => x.Key == stock.Id);
                    var stockShare = seller.Portefolio.StockShares[index];
                    if (stockShare.Key == stock.Id && stockShare.Value >= trade.StockAmount)
                    {
                        var updatedShare = new KeyValuePair<int,int>(stock.Id ,stockShare.Value - trade.StockAmount);
                        seller.Portefolio.TotalAmount -= trade.StockAmount;
                        seller.Portefolio.TotalPrice -= stock.Price * trade.StockAmount;
                        seller.Portefolio.StockShares.RemoveAt(index);
                        seller.Portefolio.StockShares.Add(updatedShare);

                        index = buyer.Portefolio.StockShares.FindIndex(x => x.Key == stock.Id);
                        if (index != -1)
                        {
                            stockShare = buyer.Portefolio.StockShares[index];
                            updatedShare = new KeyValuePair<int, int>(stock.Id, stockShare.Value + trade.StockAmount);
                            buyer.Portefolio.StockShares.RemoveAt(index);
                        } else
                        {
                            updatedShare = new KeyValuePair<int, int>(stock.Id, trade.StockAmount);
                        }
                        buyer.Portefolio.TotalAmount += trade.StockAmount;
                        buyer.Portefolio.TotalPrice += stock.Price * trade.StockAmount;
                        buyer.Portefolio.StockShares.Add(updatedShare);

                        _publicShareOwnerRepository.UpdateStockTrader(seller);
                        _publicShareOwnerRepository.UpdateStockTrader(buyer);
                        transferComplete = true;
                    }
                }
            }
            return transferComplete;
        }
    }
}
