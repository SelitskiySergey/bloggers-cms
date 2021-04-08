using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions
{
    /// <summary>
    ///     Used to create a detailed response about an exception that occurred during execution of the web api service layer
    /// </summary>
    public class ServiceException : ApplicationException
    {
        public ServiceException(string detail, int status) : this(nameof(ServiceException), detail, status)
        {
            Detail = detail;
            Status = status;
        }

        public ServiceException(string title, string detail, int status = 500,
            IDictionary<string, object> errors = null)
        {
            Title = title;
            Detail = detail;
            Status = status;
            Errors = errors;
        }

        public string Title { get; }

        public string Detail { get; }

        public int Status { get; }

        public IDictionary<string, object> Errors { get; set; }
    }
}