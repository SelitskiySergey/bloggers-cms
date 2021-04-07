using System;

namespace Pds.Api.Contracts.Exceptions
{
    public class DetailInternalErrorResponse
    {
        public DetailInternalErrorResponse(Exception exception)
        {
            Exception = exception.ToString();
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            if (exception.InnerException is not null)
                InnerDetailInternalError = new DetailInternalErrorResponse(exception.InnerException);
        }

        public string Exception { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DetailInternalErrorResponse InnerDetailInternalError { get; set; }
    }

    public class ServiceErrorDto
    {
        public string Code { get; set; }

        public object Value { get; set; }
    }
}