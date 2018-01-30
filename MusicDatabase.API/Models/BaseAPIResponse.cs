using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API
{
    public class BaseAPIResponse
    {
        public BaseAPIResponse() { }
       /* public BaseAPIResponse(object result)
        {
            this.Result = result;
            this.IsSuccess = true;
            this.Message = "";
        }

        public BaseAPIResponse(string message)
        {
            this.Message = message;
            this.Result = null;
            this.IsSuccess = false;
        }
        */
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }

    }
}
