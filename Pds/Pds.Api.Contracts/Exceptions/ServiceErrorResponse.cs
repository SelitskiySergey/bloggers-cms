 using System.Collections.Generic;

namespace Pds.Api.Contracts.Exceptions
{
    public class ServiceErrorResponse
    {
        public IReadOnlyCollection<ServiceErrorDto> Errors { get; set; }
    }
}