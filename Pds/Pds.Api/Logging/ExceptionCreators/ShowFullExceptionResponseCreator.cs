using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Pds.Api.Logging.ExceptionCreators
{
    /// <summary>
    ///     Exception creator that returns important information about occupied exception includes internal exceptions to
    ///     response
    /// </summary>
    public class ShowFullExceptionResponseCreator : ExceptionResponseCreator<Exception>
    {
        protected override Task<IActionResult> GetExceptionResultInternalAsync(Exception exception, HttpContext context)
        {
            var details = CreateFromException(exception, context);
            return Task.FromResult<IActionResult>(new ObjectResult(details)
            {
                StatusCode = details.Status,
                ContentTypes = new MediaTypeCollection
                    {"application/problem+json", MediaTypeNames.Application.Json, MediaTypeNames.Text.Plain}
            });
        }

        private static ProblemDetails CreateFromException(Exception exception, HttpContext context)
        {
            var details = new ProblemDetails
            {
                Type = exception.HelpLink,
                Title = exception.GetType().FullName,
                Detail = exception.Message,
                Status = 500,
                Instance = context.Request.Path.Value
            };
            if (exception.InnerException is not null)
                details.Extensions["InnerException"] = CreateFromException(exception, context);
            return details;
        }
    }
}