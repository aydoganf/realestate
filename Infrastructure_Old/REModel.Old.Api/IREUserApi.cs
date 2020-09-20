using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REModel.Old.Api
{
    public interface IREUserApi
    {
        [Post("/")]
        Task<ApiResponse<User>> AddUserAsync([Header("Authorization")] string authorization, [Body()] User user);

        [Get("/{id}")]
        Task<ApiResponse<User>> GetUserAsync([Header("Authorization")] string authorization, Guid id);

        [Get("/")]
        Task<ApiResponse<List<User>>> GetAllUsersAsync([Header("Authorization")] string authorization);
    }
}
