using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REModel.Old.Api
{
    public interface IREAdvertApi
    {
        [Post("/")]
        Task<ApiResponse<Advert>> AddAdvertAsync([Header("Authorization")] string authorization, [Body()] Advert advert);

        [Get("/")]
        Task<ApiResponse<List<Advert>>> GetAllAdvertAsync([Header("Authorization")] string authorization);

        [Get("/{id}")]
        Task<ApiResponse<Advert>> GetAdvertAsync([Header("Authorization")] string authorization, Guid id);
    }
}
