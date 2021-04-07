using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Pds.Api.Contracts.Exceptions;
using Pds.Core.Exceptions;

namespace Pds.Api.Logging.ExceptionCreators
{
    public class ServiceExceptionResponseCreator : ExceptionResponseCreator<ServiceException>
    {
        protected override Task<IActionResult> GetExceptionResultInternalAsync(ServiceException exception, IServiceProvider provider)
        {
            var details = new ProblemDetails()
            {
                Title = TargetExceptionType.ToString().Replace("Exception", "Error"),
                Detail = "Error occupied",
                Status = 400

            };
            return Task.FromResult(new BadRequestObjectResult(mapper.Map<ProblemDetails>(exception)) as IActionResult);
        }
    }
}