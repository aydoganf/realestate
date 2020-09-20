using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace REModel.Api.Core
{
    public static class Extensions
    {
        public static ActionResult<ApiResponse<T>> NotFound<T>(this Controller controller)
            where T : class
        {
            return controller.NotFound(new { ResultMessage = $"The type of {typeof(T)} is not found!" });
        }

        public static ApiResponse<T> Build<T>(this Controller controller, T obj, 
            string responseCode = "0", string responseMessage = "Success")
            where T : class
        {
            return new ApiResponse<T>()
            {
                Response = obj,
                ResponseCode = responseCode,
                ResponseMessage = responseMessage
            };
        }
    }
}
