using System.Collections.Generic;

namespace Pds.Core.Exceptions
{
    public sealed class PersonServiceException : ServiceException
    {
        public PersonServiceException(string detail, int status) : base(nameof(PersonServiceException), detail,
            status)
        {
        }

        public PersonServiceException(string title, string detail, int status = 400,
            IDictionary<string, object> errors = null) : base(title, detail, status, errors)
        {
        }
    }
}