using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockTraderBroker.Repositories;

namespace StockTraderBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTraderBrokersController : ControllerBase
    {
        private readonly ILogger<StockTraderBrokersController> _logger;
        private IStockTransactionRepository _dbContext;

        public StockTraderBrokersController(ILogger<StockTraderBrokersController> logger, IStockTransactionRepository context)
        {
            _logger = logger;
            _dbContext = context;
        }

    }
}