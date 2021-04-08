using System.Collections.Generic;

namespace Pds.Core.Exceptions
{
    public class NotFoundException : ServiceException
    {
        public NotFoundException(string resourceName,
            string messageTemplate = "{0} not found.") : base("ResourceNotFound",
            string.Format(messageTemplate,
                resourceName),
            404)
        {
        }

        public NotFoundException(string detail, int status) : base(detail, status)
        {
        }

        public NotFoundException(string title,
            string detail,
            int status = 500,
            IDictionary<string, object> errors = null) : base(title,
            detail,
            status,
            errors)
        {
        }
    }
}