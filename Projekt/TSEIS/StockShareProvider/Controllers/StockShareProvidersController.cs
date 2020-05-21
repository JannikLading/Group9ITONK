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
        private string TraderBrokerApiBase = "some Uri";
        private string TraderBrokerApiGetShare = "some Uri";
        public async Task<IActionResult> AddTradeAsync([FromBody] SellerDto stock)
        {
            if(stock == null)
            {
                return BadRequest();
            }
            string json = JsonConvert.SerializeObject(stock);
            HttpResponseMessage response = await client.PostAsync(TraderBrokerApiBase + TraderBrokerApiGetShare, new StringContent(json, Encoding.UTF8, "application/json"));

            string responseResult = await response.Content.ReadAsStringAsync();
            if (responseResult.Contains("Ok"))
            {
                return Ok(response.Content.ReadAsStringAsync());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}