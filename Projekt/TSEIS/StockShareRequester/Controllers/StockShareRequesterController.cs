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
        private string TraderBrokerApiGetSharesUri = "some Uri";
        private string TraderBrokerApiRequestTradeUri = "some Uri";


        [HttpGet]
        public async Task<IEnumerable<StockTrade>> GetActiveShares()
        {
            HttpResponseMessage response = await client.GetAsync(TraderBrokerApiGetSharesUri);

            string responseResult = await response.Content.ReadAsStringAsync();
            if (responseResult != null)
            {
                List<StockTrade> trades = (List<StockTrade>)JsonConvert.DeserializeObject(responseResult);
                return trades;
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        public async Task<IActionResult> RequestTrade([FromBody] Models.UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            string json = JsonConvert.SerializeObject(user);
            HttpResponseMessage response = await client.PostAsync(TraderBrokerApiRequestTradeUri, new StringContent(json, Encoding.UTF8, "application/json"));

            string responseResult = await response.Content.ReadAsStringAsync();

            return (IActionResult)response;
        }
    }
}