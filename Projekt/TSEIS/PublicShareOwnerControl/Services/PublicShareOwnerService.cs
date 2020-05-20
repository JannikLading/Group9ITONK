using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        public PublicShareOwnerService(ILogger<PublicShareOwnerService> logger, IPublicShareOwnerRepository publicShareOwnerRepository)
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
                if (seller != null && buyer != null)
                {
                    var portefolioSeller = JsonConvert.DeserializeObject<List<KeyValuePair<int, int>>>(seller.Portefolio.StockShares);
                    var index = portefolioSeller.FindIndex(x => x.Key == stock.Id);
                    var stockShare = portefolioSeller[index];
                    if (stockShare.Key == stock.Id && stockShare.Value >= trade.StockAmount)
                    {
                        var updatedShare = new KeyValuePair<int,int>(stock.Id ,stockShare.Value - trade.StockAmount);
                        seller.Portefolio.TotalAmount -= trade.StockAmount;
                        seller.Portefolio.TotalPrice -= stock.Price * trade.StockAmount;
                        portefolioSeller.RemoveAt(index);
                        portefolioSeller.Add(updatedShare);
                        seller.Portefolio.StockShares = portefolioSeller.ToString();

                        var portefolioBuyer= JsonConvert.DeserializeObject<List<KeyValuePair<int, int>>>(buyer.Portefolio.StockShares);
                        index = portefolioBuyer.FindIndex(x => x.Key == stock.Id);
                        if (index != -1)
                        {
                            stockShare = portefolioBuyer[index];
                            updatedShare = new KeyValuePair<int, int>(stock.Id, stockShare.Value + trade.StockAmount);
                            portefolioBuyer.RemoveAt(index);
                            buyer.Portefolio.StockShares = portefolioBuyer.ToString();
                        } else
                        {
                            updatedShare = new KeyValuePair<int, int>(stock.Id, trade.StockAmount);
                        }
                        buyer.Portefolio.TotalAmount += trade.StockAmount;
                        buyer.Portefolio.TotalPrice += stock.Price * trade.StockAmount;
                        portefolioBuyer.Add(updatedShare);
                        buyer.Portefolio.StockShares = portefolioBuyer.ToString();

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
