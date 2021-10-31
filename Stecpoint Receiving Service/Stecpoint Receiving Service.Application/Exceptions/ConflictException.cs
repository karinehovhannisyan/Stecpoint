using Microsoft.AspNetCore.Http;
using System;

namespace Stecpoint_Receiving_Service.Application.Exceptions
{
    public class ConflictException: Exception, ICustomException
    {
        public ConflictException(string message): base(message) {}

        public int GetErrorCode() => StatusCodes.Status400BadRequest;
    }
}
