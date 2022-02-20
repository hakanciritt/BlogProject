using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ResponseModel
{

    public class ApiResponse<T>
    {
        public List<ErrorDto> Errors { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
