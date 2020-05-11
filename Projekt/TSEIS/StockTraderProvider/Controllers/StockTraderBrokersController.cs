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
using StockTraderBroker.Models;
using StockTraderBroker.Repositories;
using StockTraderBroker.Services;

namespace StockTraderBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTraderBrokersController : ControllerBase
    {

        private HttpClient _client = new HttpClient();
        private string _tobinApiPostString = "some Uri";

        private readonly ILogger<StockTraderBrokersController> _logger;
        private IStockTraderBrokerService _stockTraderBrokerService; 

        public StockTraderBrokersController(ILogger<StockTraderBrokersController> logger, IStockTraderBrokerService stockTraderBrokerService)
        {
            _logger = logger;
            _stockTraderBrokerService = stockTraderBrokerService;
        }


        //POST: api/StockTraderBrokers
        [HttpPost]
        public IActionResult AddTrade([FromBody] StockTrade trade)
        {
            if (trade == null)
            {
                _stockTraderBrokerService.AddStockTrade(trade);
                return Ok(trade);
            } else
            {
                return BadRequest();
            }
        }

        //GET: api/StockTraderBrokers
        [HttpGet]
        public IEnumerable<StockTrade> GetActiveTrades()
        {
            return _stockTraderBrokerService.GetStockTrades(); 
        }

        //PUT: api/StockTrade/id
        [HttpPut("{id}")]
        public async Task<IActionResult> AddBuyerToTrade(int id, [FromBody] int buyerId)
        {
            StockTrade stockTrade = _stockTraderBrokerService.UpdateBuyerOnStockTrade(id, buyerId);

            if (stockTrade == null)
            {
                return BadRequest();
            }

            string json = JsonConvert.SerializeObject(stockTrade);

            HttpResponseMessage response = await _client.PostAsync(_tobinApiPostString, new StringContent(json, Encoding.UTF8, "application/json"));

            string responseResult = await response.Content.ReadAsStringAsync();
            if (responseResult.Contains("Ok"))
            {
                StockTrade stockTradeResponse = (StockTrade)JsonConvert.DeserializeObject(responseResult);
                _stockTraderBrokerService.DeleteStockTrade(stockTradeResponse.Id); 
                return Ok(stockTradeResponse);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}