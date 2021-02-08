using CustomerHomework.Shared.Entities.Concrete;
using CustomerHomework.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Shared.Utilities.Results.ComplexTypes
{
    public class Result: IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            ValidationErrors = validationErrors;

        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            Message = message;
            ValidationErrors = validationErrors;
        }
        public Result(ResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public Result(ResultStatus resultStatus, string message, IEnumerable<ValidationError> validationErrors, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            ValidationErrors = validationErrors;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public IEnumerable<ValidationError> ValidationErrors { get; }
    }
}
