using Microsoft.AspNetCore.Http;
using System;

namespace Stecpoint_Receiving_Service.Application.Exceptions
{
    public class NotFoundException : Exception, ICustomException
    {
        public NotFoundException(string message): base(message) {}

        public int GetErrorCode() => StatusCodes.Status404NotFound;
    }
}
