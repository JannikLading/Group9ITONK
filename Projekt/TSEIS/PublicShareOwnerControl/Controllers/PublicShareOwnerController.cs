using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PublicShareOwnerControl.Models;
using PublicShareOwnerControl.Services;
using StockTraderBroker.Models;
using TradedShares.Models;

namespace PublicShareOwnerControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicShareOwnerController : ControllerBase
    {
        private ILogger<PublicShareOwnerController> _logger;
        private IPublicShareOwnerService _publicShareOwnerService;
        private HttpClient client = new HttpClient();
        readonly string getTradedShare = "http://192.168.87.172:1337/api/TradedShares";

        public PublicShareOwnerController(ILogger<PublicShareOwnerController> logger, IPublicShareOwnerService PSOservice)
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

        [HttpPost]
        [Route("Transferstocks")]
        public async Task<IActionResult> TransferStocks([FromBody]StockTrade trade)
        {
            if(trade == null || trade.StockTransferComplete == true)
            {
                return BadRequest("Trade object is null or stock transfer is already complete");
            }

            HttpResponseMessage response = await client.GetAsync(getTradedShare+'/'+trade.TransferStockId);
            string responseResult = await response.Content.ReadAsStringAsync();
            var transferStock = JsonConvert.DeserializeObject<Stock>(responseResult);
            if(_publicShareOwnerService.TransferStocks(trade, transferStock))
            {
                trade.StockTransferComplete = true;
                return Ok(trade);
            }else
            {
                return BadRequest("Failed to transfer stocks");
            }
        }
    }
}