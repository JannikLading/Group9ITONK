using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Users.Models;
using Users.Repositories;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet]
        [Route("/api/[controller]/GetTransactionUsers")]
        public UsersDto GetTransactionUsers([FromBody] UsersDto users)
        {
            users.Buyer = _userRepository.GetById(users.Buyer.Id);
            users.Seller = _userRepository.GetById(users.Seller.Id);
            return users;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _userRepository.AddUser(user);
            return Ok(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.DeleteUser(id);
        }

        // POST api/<controller>
        [HttpPut]
        public IActionResult Put([FromBody]UsersDto users)
        {
            _userRepository.UpdateUser(users.Buyer);
            _userRepository.UpdateUser(users.Seller);
            return Ok(users);
        }

    }
}