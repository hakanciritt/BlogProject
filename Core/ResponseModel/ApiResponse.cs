using Dtos;
using System.Collections.Generic;

namespace Core.ResponseModel
{

    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public List<ErrorDto> Errors { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
