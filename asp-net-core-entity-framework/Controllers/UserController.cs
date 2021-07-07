using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace asp_net_core_entity_framework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        [HttpGet("GetUser")]
        public async Task<User> GetAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
            {
                return new NotFoundObjectResult();
            }

            return user;
        }

        [HttpPost("CreateUser")]
        public async Task CreateAsync(User user)
        {
            await _repository.CreateAsync(user);
        }
    }
}