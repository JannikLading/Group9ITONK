using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockTraderBroker.Models;

namespace StockShareRequester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockShareRequesterController : ControllerBase
    {
        private HttpClient client = new HttpClient();
        private string TraderBrokerApiGetActiveTradesUri = "http://stb-service-g9:6974/api/stocktraderbrokers/trades";
        private string TraderBrokerApiRequestTradeUri = "http://stb-service-g9:6974/api/stocktraderbrokers/trades";


        [HttpGet]
        public async Task<IEnumerable<StockTrade>> GetActiveShares()
        {
            HttpResponseMessage response = await client.GetAsync(TraderBrokerApiGetActiveTradesUri);

            string responseResult = await response.Content.ReadAsStringAsync();
            if (responseResult != null)
            {
                var trades = JsonConvert.DeserializeObject<List<StockTrade>>(responseResult);
                return trades;
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        public async Task<IActionResult> RequestTrade([FromBody] BuyerDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            string userJson = JsonConvert.SerializeObject(user);
            HttpResponseMessage response = await client.PutAsync(TraderBrokerApiRequestTradeUri+"/"+user.StockTradeId+"/buy", new StringContent(userJson, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseResult = await response.Content.ReadAsStringAsync();
                StockTrade stockTradeResponse = JsonConvert.DeserializeObject<StockTrade>(responseResult);
                if (stockTradeResponse != null && stockTradeResponse.StockTransferComplete != false && stockTradeResponse.TransactionComplete != false)
                {
                    return Ok(stockTradeResponse);
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            return (IActionResult)response;
        }
    }
}