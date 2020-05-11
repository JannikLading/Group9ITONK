using Microsoft.Extensions.Logging;
using PublicShareOwnerControl.Models;
using PublicShareOwnerControl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void ApproveTrade()
        {

        }
    }
}
