using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delopgaveprojekt.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 

namespace Delopgaveprojekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaerktoejController : ControllerBase
    {

        private readonly ILogger<VaerktoejController> _logger;
        private IVaerktoejRepository _vaerktoejRepository;

        public VaerktoejController(ILogger<VaerktoejController> logger, IVaerktoejRepository vaerktoejRepository)
        {
            _vaerktoejRepository = vaerktoejRepository;
            _logger = logger;
        }

        // GET: api/Vaerktoej
        [HttpGet]
        public List<Models.Vaerktoej> Get()
        {
            return _vaerktoejRepository.GetVaerktoejs();
        }

        // GET: api/Vaerktoej/5
        [HttpGet("{id}")]
        public Models.Vaerktoej Get(int id)
        {
            return _vaerktoejRepository.GetById(id);
        }

        // POST: api/Vaerktoej
        [HttpPost]
        public void Post([FromBody] Models.Vaerktoej vt)
        {
            _vaerktoejRepository.AddVaerktoej(vt);
        }

        // PUT: api/Vaerktoej/5
        [HttpPut]
        public void Put([FromBody] Models.Vaerktoej vt)
        {
            _vaerktoejRepository.UpdateVaerktoej(vt);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete([FromBody]Models.Vaerktoej vt)
        {
            _vaerktoejRepository.DeleteVaerktoej(vt);
        }
    }
}
