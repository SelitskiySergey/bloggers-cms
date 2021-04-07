using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Pds.Core.Exceptions
{
    /// <summary>
    ///     Used to create a detailed response about an exception that occurred during execution of the web api service layer
    /// </summary>
    public class ServiceException : ApplicationException
    {
        public ServiceException()
        {
            Errors = new List<ServiceError>(0);
        }

        public ServiceException(ServiceError singleError)
        {
            Errors = new List<ServiceError>(0)
            {
                singleError
            };
        }

        public ServiceException(IEnumerable<ServiceError> errors)
        {
            Errors = errors as ICollection<ServiceError> ?? errors.ToList();
        }

        public class ServiceError
        {
            public string Code { get; set; }

            public object Value { get; set; }

            public ServiceError(object value)
            {
                Code = value.ToString();
                Value = value;
            }

            public ServiceError(string code, object value)
            {
                Code = code;
                Value = value;
            }

            public static implicit operator ServiceError (string value) => new ServiceError(value);

            public static IEnumerable<ServiceError>
                FromDictionary(IEnumerable<KeyValuePair<string, object>> dictionary) =>
                dictionary.Select((pair) => new ServiceError(pair.Key, pair.Value));
            
            public static IEnumerable<ServiceError>
                FromObjects(IEnumerable<object> dictionary) =>
                dictionary.Select((obj) => new ServiceError(obj.ToString(), obj));
        }
        
        public ICollection<ServiceError> Errors { get; set; }
    }
}