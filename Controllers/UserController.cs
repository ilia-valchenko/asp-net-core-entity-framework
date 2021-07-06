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

        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(User user)
        {
            var resultCode = await _repository.CreateAsync(user);
            return resultCode != 3 ? new StatusCodeResult(201) : new StatusCodeResult(500);
        }
    }
}