using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public TobinTaxingsController(ILogger<TobinTaxingsController> logger, ITaxRegistrationRepository context, TobinTransactionService service)
        {
            _logger = logger;
            _dbContext = context;
            _tobinService = service;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] StockTransaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }
            var newtaxRegistration = _tobinService.CreatetaxRegistrationFromTransaction(transaction);
            _dbContext.addTaxRegistration(newtaxRegistration);
            return Ok(newtaxRegistration);
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