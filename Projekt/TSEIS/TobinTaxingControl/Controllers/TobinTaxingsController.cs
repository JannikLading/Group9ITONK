using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TobinTaxingControl.Database;
using TobinTaxingControl.Models;
using TobinTaxingControl.Repositories;

namespace TobinTaxingControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobinTaxingsController : ControllerBase
    {
        private readonly ILogger<TobinTaxingsController> _logger;
        private ITaxRegistrationRepository _dbContext;

        public TobinTaxingsController(ILogger<TobinTaxingsController> logger, ITaxRegistrationRepository context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public IEnumerable<TaxRegistration> Get()
        {
            return _dbContext.getTaxRegistrations();

        }
    }
}