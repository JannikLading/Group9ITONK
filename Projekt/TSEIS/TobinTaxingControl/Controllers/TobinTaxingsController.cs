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
        private readonly string TransactionApiPostString = "/api/transaction";

        public TobinTaxingsController(ILogger<TobinTaxingsController> logger, ITaxRegistrationRepository context, TobinTransactionService service)
        {
            _logger = logger;
            _dbContext = context;
            _tobinService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionAsync([FromBody] StockTransaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }
            var newtaxRegistration = _tobinService.CreatetaxRegistrationFromTransaction(transaction);

            string json = JsonConvert.SerializeObject(transaction);


            HttpResponseMessage response = await client.PostAsync(TransactionApiPostString, new StringContent(json, Encoding.UTF8, "application/json"));

            string responseResult = await response.Content.ReadAsStringAsync();
            if (responseResult.Contains("OK"))
            {
                _dbContext.addTaxRegistration(newtaxRegistration);
                return Ok(newtaxRegistration);
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