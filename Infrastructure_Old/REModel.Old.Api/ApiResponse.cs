using System;

namespace REModel.Old.Api
{
    public class ApiResponse<T> where T : class
    {
        public T Response { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
