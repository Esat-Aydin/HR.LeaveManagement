using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string ValidationErrors { get; set; }
        public T Data { get; set; }
    }
}