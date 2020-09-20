using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REModel;
using REModel.Api;
using REModel.Api.Core;
using TestApi.Domain.Repositories;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpGet()]
        public async Task<ActionResult<ApiResponse<List<User>>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (users == null)
                return this.NotFound<List<User>>();

            return this.Build(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<User>>> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            if (user == null)
                return this.NotFound<User>();

            return this.Build(user);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<User>>> AddUserAsync([FromBody] User user)
        {
            var addedUser = await _userRepository.AddAsync(user);

            return this.Build(addedUser);
        }
    }
}
