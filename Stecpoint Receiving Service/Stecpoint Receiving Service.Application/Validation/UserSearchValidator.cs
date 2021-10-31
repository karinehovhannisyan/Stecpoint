using FluentValidation;
using Stecpoint_Receiving_Service.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stecpoint_Receiving_Service.Application.Validation
{
    public class UserSearchValidator: AbstractValidator<UserSearchDto>
    {
        public UserSearchValidator()
        {
            RuleFor(s => s.PageNumber).GreaterThan(0);
            RuleFor(s => s.PageSize).GreaterThan(0);
            RuleFor(s => s.OrganizationId).GreaterThan(0);
        }
    }
}
