using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REModel.Api
{
    public interface IREUserApi
    {
        [Post("/")]
        Task<User> AddUserAsync([Header("Authorization")] string authorization, [Body()] User user);

        [Get("/{id}")]
        Task<User> GetUserAsync([Header("Authorization")] string authorization, Guid id);

        [Get("/")]
        Task<List<User>> GetAllUsersAsync([Header("Authorization")] string authorization);
    }
}
