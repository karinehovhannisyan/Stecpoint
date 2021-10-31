using Microsoft.AspNetCore.Http;
using System;

namespace Stecpoint_Receiving_Service.Application.Exceptions
{
    public class BadRequestException : Exception, ICustomException
    {
        public BadRequestException(string message): base(message) {}

        public int GetErrorCode() => StatusCodes.Status400BadRequest;
    }
}
