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
        private string _tobinApiString = "http://192.168.87.172:6973/api/tobintaxings";

        private readonly ILogger<StockTraderBrokersController> _logger;
        private IStockTraderBrokerService _stockTraderBrokerService; 

        public StockTraderBrokersController(ILogger<StockTraderBrokersController> logger, IStockTraderBrokerService stockTraderBrokerService)
        {
            _logger = logger;
            _stockTraderBrokerService = stockTraderBrokerService;
        }

        //POST: api/StockTraderBrokers
        [HttpPost]
        public IActionResult AddTrade([FromBody] SellerDto sellerDto)
        {
            if (sellerDto != null)
            {
                _stockTraderBrokerService.AddStockTrade(sellerDto);
                return Ok(sellerDto);
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

        //PUT: api/StockTraderBrokers/id
        [HttpPut]
        public async Task<IActionResult> AddBuyerToTrade([FromBody] BuyerDto buyerdto)
        {
            StockTrade stockTrade = _stockTraderBrokerService.UpdateBuyerOnStockTrade(buyerdto.StockTradeId, buyerdto.StockBuyerId);

            if (stockTrade == null)
            {
                return BadRequest($"No trades with the id found");
            }

            string json = JsonConvert.SerializeObject(stockTrade);

            HttpResponseMessage response = await _client.PostAsync(_tobinApiString, new StringContent(json, Encoding.UTF8, "application/json"));
            string responseResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var stockTradeResponse = JsonConvert.DeserializeObject<StockTrade>(responseResult);
                _stockTraderBrokerService.DeleteStockTrade(stockTradeResponse.Id); 
                return Ok(stockTradeResponse);
            }
            else
            {
                return BadRequest(response.Content);
            }
        }
    }
}