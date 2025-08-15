using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GazTestTask.WebApi.Filters
{
    public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, "Возникло исключение: {message}", context.Exception.Message);

            var result = new ObjectResult(new())
            {
                StatusCode = context.Exception switch
                {
                    ArgumentException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                }
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
