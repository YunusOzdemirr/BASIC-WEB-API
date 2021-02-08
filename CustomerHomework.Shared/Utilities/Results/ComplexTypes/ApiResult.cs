using CustomerHomework.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Shared.Utilities.Results.ComplexTypes
{
    public class ApiResult
    {
        public string Href { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public Object Data { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
