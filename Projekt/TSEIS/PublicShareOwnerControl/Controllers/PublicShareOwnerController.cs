using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublicShareOwnerControl.Models;
using PublicShareOwnerControl.Services;

namespace PublicShareOwnerControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicShareOwnerController : ControllerBase
    {
        private ILogger<PublicShareOwnerController> _logger;
        private IPublicShareOwnerService _publicShareOwnerService;

        PublicShareOwnerController(ILogger<PublicShareOwnerController> logger, IPublicShareOwnerService PSOservice)
        {
            _logger = logger;
            _publicShareOwnerService = PSOservice;
        }

        [HttpGet]
        public List<StockTrader> Get()
        {
            return _publicShareOwnerService.GetStockTraders();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public StockTrader Get(int id)
        {
            return _publicShareOwnerService.GetStockTrader(id);
        }
    }
}