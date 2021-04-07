using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions
{
    public class PersonCreationException : ServiceException
    {
        public PersonCreationException()
        {
        }

        public PersonCreationException(ServiceError singleError) : base(singleError)
        {
        }

        public PersonCreationException(IEnumerable<ServiceError> errors) : base(errors)
        {
        }
    }
}