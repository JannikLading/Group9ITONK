using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Delopgaveprojekt.Repositories;
using Microsoft.Extensions.Logging;

namespace Delopgaveprojekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaerktoejskasseController : ControllerBase
    {
        private IVaerktoejskasseRepository _vaerktoejskasseRepository;
        private readonly ILogger<VaerktoejskasseController> _logger;

        public VaerktoejskasseController(ILogger<VaerktoejskasseController> logger, IVaerktoejskasseRepository vaerktoejskasseRepository)
        {
            _vaerktoejskasseRepository = vaerktoejskasseRepository;
            _logger = logger;
        }

        // GET: api/Vaerktoejskasse
        [HttpGet]
        public List<Models.Vaerktoejskasse> Get()
        {
            return _vaerktoejskasseRepository.GetVaerktoejskasses();
        }

        // GET: api/Vaerktoejskasse/5
        [HttpGet("{id}")]
        public Models.Vaerktoejskasse Get(int id)
        {
            return _vaerktoejskasseRepository.GetById(id);
        }

        // POST: api/Vaerktoejskasse
        [HttpPost]
        public void Post([FromBody] Models.Vaerktoejskasse vk)
        {
            _vaerktoejskasseRepository.AddVaerktoejskasse(vk);
        }

        // PUT: api/Vaerktoejskasse/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Vaerktoejskasse vk)
        {
            _vaerktoejskasseRepository.UpdateVaerktoejskasse(vk);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vaerktoejskasseRepository.DeleteVaerktoejskasse(id);
        }
    }
}
