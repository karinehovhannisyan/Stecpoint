using System;
using System.Collections.Generic;
using System.Text;

namespace Stecpoint_Receiving_Service.Application.Exceptions
{
    public interface ICustomException
    {
        int GetErrorCode();
    }
}
