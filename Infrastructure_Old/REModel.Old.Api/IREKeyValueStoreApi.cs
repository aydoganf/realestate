using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REModel.Old.Api
{
    public interface IREKeyValueStoreApi
    {
        [Get("/type/{type}")]
        Task<ApiResponse<List<KeyValueStore>>> GetByType([Header("Authorization")] string authorization, string type);

        [Get("/type/{type}/parent/{parent}")]
        Task<ApiResponse<List<KeyValueStore>>> GetByTypeAndParent([Header("Authorization")] string authorization, string type, string parent);

        [Get("/{id}")]
        Task<ApiResponse<KeyValueStore>> GetById([Header("Authorization")] string authorization, Guid id);

        [Get("/{id}/parent")]
        Task<ApiResponse<KeyValueStore>> GetParentById([Header("Authorization")] string authorization, Guid id);

        [Post("/")]
        Task<ApiResponse<KeyValueStore>> Add([Header("Authorization")] string authorization, KeyValueStore obj);

        [Put("/{id}")]
        Task<ApiResponse<KeyValueStore>> Update([Header("Authorization")] string authorization, Guid id, KeyValueStore obj);

        [Delete("/{id}")]
        Task Delete([Header("Authorization")] string authorization, Guid id);
    }
}
