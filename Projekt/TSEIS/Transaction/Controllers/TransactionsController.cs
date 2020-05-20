﻿using System;
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
using Transaction.Models;

namespace Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        private HttpClient client = new HttpClient();
        private string UsersApiGetUsersUri = "some Uri";
        private string UsersApiUpdateUsersUri = "some Uri";

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }
        
        // POST: api/Transactions
        [HttpPost]
        public async Task <IActionResult> addTransaction([FromBody] StockTrade transaction)
        {
            string json = JsonConvert.SerializeObject(transaction);
            HttpResponseMessage response = await client.PostAsync(UsersApiGetUsersUri, new StringContent(json, Encoding.UTF8, "application/json"));

            string responseResult = await response.Content.ReadAsStringAsync();

            UsersViewModel users = (UsersViewModel)JsonConvert.DeserializeObject(responseResult);

            users.buyer.Balance -= ((transaction.StockPrice*transaction.StockAmount)+ (Double)transaction.TaxAmount);
            users.seller.Balance += transaction.StockPrice * transaction.StockAmount;

            string userJson = JsonConvert.SerializeObject(users);

            HttpResponseMessage responseUpdate = await client.PostAsync(UsersApiUpdateUsersUri, new StringContent(userJson, Encoding.UTF8, "application/json"));

            string responseResultUpdate = await responseUpdate.Content.ReadAsStringAsync();
            if (responseResultUpdate.Contains("Ok"))
            {
                return Ok(users);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
