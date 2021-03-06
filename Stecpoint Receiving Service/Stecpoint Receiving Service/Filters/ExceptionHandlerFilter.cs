using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Stecpoint_Receiving_Service.Application.Exceptions;
using System.Net;

namespace Stecpoint_Receiving_Service.API.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlerFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message);

            var statusCode = StatusCodes.Status500InternalServerError;
            if (context.Exception is ICustomException customException)
                statusCode = customException.GetErrorCode();

            var jsonResponse = new JsonErrorResponse
            {
                Messages = new[] { "An error occured." }
            };

            if (_env.IsDevelopment())
                jsonResponse.DeveloperMessage = context.Exception;

            var objectResult = new ObjectResult(jsonResponse) { StatusCode = statusCode };

            context.Result = objectResult;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }
    }
}