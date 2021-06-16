using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ErrorResponse
    {
        public List<errorModel> errores { get; set; }
        public ErrorResponse()
        {
            errores = new List<errorModel>();
        }
    }
    public class errorModel
    {
        public string error { get; set; }
    }
}