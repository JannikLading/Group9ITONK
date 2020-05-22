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
using TobinTaxingControl.Database;
using TobinTaxingControl.Models;
using TobinTaxingControl.Repositories;
using TobinTaxingControl.Services;

namespace TobinTaxingControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobinTaxingsController : ControllerBase
    {
        private readonly ILogger<TobinTaxingsController> _logger;
        private ITaxRegistrationRepository _dbContext;
        private TobinTransactionService _tobinService;
        private HttpClient client= new HttpClient();
        private readonly string TransactionBase = "http://t-service-g9:6972";
        private readonly string TransactionApiPostString = "/api/transactions/maketransaction";

        public TobinTaxingsController(ILogger<TobinTaxingsController> logger, ITaxRegistrationRepository context, TobinTransactionService service)
        {
            _logger = logger;
            _dbContext = context;
            _tobinService = service;
        }

        [HttpPost]
        [Route("registertax")]
        public async Task<IActionResult> AddTransactionAsync([FromBody] StockTrade transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }
            var newtaxRegistration = _tobinService.CreatetaxRegistrationFromTransaction(transaction);

            string json = JsonConvert.SerializeObject(transaction);

            HttpResponseMessage response = await client.PostAsync(TransactionBase+TransactionApiPostString, new StringContent(json, Encoding.UTF8, "application/json"));

            string responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                _dbContext.addTaxRegistration(newtaxRegistration);
                return Ok(responseResult);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        public bool IsApproved(int id)
        {
            var registration = _dbContext.getById(id);
            if (registration == null) { return false; }
            return registration.Approved;
        }
    }
}