using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Pds.Core.Exceptions;

namespace Pds.Api.Logging.ExceptionCreators
{
    public class ServiceExceptionResponseCreator : ExceptionResponseCreator<ServiceException>
    {
        protected override Task<IActionResult> GetExceptionResultInternalAsync(ServiceException exception,
            HttpContext context)
        {
            var details = new ProblemDetails
            {
                Type = exception.HelpLink,
                Title = exception.Title,
                Detail = exception.Detail,
                Status = exception.Status,
                Instance = context.Request.Path.Value
            };
            foreach (var (key, value) in exception.Errors) details.Extensions[key] = value;
            return Task.FromResult<IActionResult>(new ObjectResult(details)
            {
                StatusCode = details.Status,
                ContentTypes = new MediaTypeCollection
                    {"application/problem+json", MediaTypeNames.Application.Json, MediaTypeNames.Text.Plain}
            });
        }
    }
}