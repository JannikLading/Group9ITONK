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

namespace StockShareProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockShareProvidersController : ControllerBase
    {
        private HttpClient client = new HttpClient();
        private string TraderBrokerApiAddTrade= "http://stb-service-g9:6974/api/stocktraderbrokers/trades/add";
        public async Task<IActionResult> AddTradeAsync([FromBody] SellerDto stock)
        {
            if(stock == null || stock.StockAmount == 0 || stock.StockSellerId==0)
            {
                return BadRequest("SellerDto is not valid");
            }
            string json = JsonConvert.SerializeObject(stock);
            HttpResponseMessage response = await client.PostAsync(TraderBrokerApiAddTrade, new StringContent(json, Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Ok(result);
            }
            else
            {
                return (IActionResult)response;
            }
        }
    }
}