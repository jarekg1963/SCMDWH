using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared
{
    public class CustomResponse
    {
        public CustomResponse()
        {
            isSuccess = true;
            statusCode = HttpStatusCode.OK;
            errors = new List<Error>();
            message = "OK";
        }

        public class Error
        {
            public string ErrorMessage { get; set; }
            public Exception ex { get; set; }
        }
        public bool isSuccess { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public List<Error> errors { get; set; }
        public List<object> results { get; set; }


    }
}
