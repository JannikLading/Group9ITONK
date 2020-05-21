using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockTraderBroker.Models;
using Transaction.Models;
using Users.Models;

namespace Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        private HttpClient client = new HttpClient();
        private string UsersApiUri = "http://localhost:1337/api/Users";

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }
        
        // POST: api/Transactions
        [HttpPost]
        public async Task <IActionResult> addTransaction([FromBody] StockTrade transaction)
        {
            //string json = JsonConvert.SerializeObject(transaction);
            User buyer = new User { Id = (int)transaction.StockBuyerId };
            User seller = new User { Id = transaction.StockSellerId }; 
            UsersDto usersDto = new UsersDto { Seller = seller, Buyer = buyer };

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(UsersApiUri + "/GetTransactionUsers"),
                Content = new StringContent(JsonConvert.SerializeObject(usersDto), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage responseUsers = await client.SendAsync(request); 
            string responseResultUsers = await responseUsers.Content.ReadAsStringAsync();

            if (responseUsers.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }

            UsersDto usersDtoResponse = JsonConvert.DeserializeObject<UsersDto>(responseResultUsers);

            usersDtoResponse.Buyer.Balance -= ((transaction.StockPrice*transaction.StockAmount)+ (Double)transaction.TaxAmount);
            usersDtoResponse.Seller.Balance += transaction.StockPrice * transaction.StockAmount;

            string usersDtoString = JsonConvert.SerializeObject(usersDtoResponse);

            HttpResponseMessage responseUsersUpdate = await client.PutAsync(UsersApiUri + "/", new StringContent(usersDtoString, Encoding.UTF8, "application/json"));
            string responseSellerResultUpdate = await responseUsersUpdate.Content.ReadAsStringAsync();
            if (responseUsersUpdate.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }
            transaction.TransactionComplete = true;

            // Missing PSO communication

            return Ok(transaction);
        }
    }
}
