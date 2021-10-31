using FluentValidation;
using Stecpoint_Sending_Service.Application.Commands;

namespace Stecpoint_Sending_Service.Validation
{
    public class UserValidator : AbstractValidator<AddUserCommand>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
