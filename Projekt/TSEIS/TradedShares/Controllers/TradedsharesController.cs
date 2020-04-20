using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradedShares.Models;
using TradedShares.Repositories;

namespace TradedShares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradedsharesController : ControllerBase
    {
        private IStockRepository _stockRepository;
        private readonly ILogger<TradedsharesController> _logger;

        public TradedsharesController(ILogger<TradedsharesController> logger, IStockRepository stockRepository)
        {
            //_logger = logger;
            _stockRepository = stockRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return _stockRepository.GetStocks();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            return _stockRepository.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Stock stock)
        {
            _stockRepository.AddStock(stock);
            return Ok(stock);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _stockRepository.DeleteStock(id);
        }

    }
}