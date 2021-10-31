using Serilog;
using Stecpoint_Receiving_Service.Application.DataTransferObjects;
using Stecpoint_Receiving_Service.Application.Services;
using System.Threading.Tasks;

namespace MassTransit.Messages
{
    public class UserAddedConsumer: IConsumer<UserAddedMessage>
    {
        private readonly IUserService _userService;

        public UserAddedConsumer() {}
        public UserAddedConsumer(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Consume(ConsumeContext<UserAddedMessage> context)
        {
            Log.Information("Message Received: {@messageType}", nameof(UserAddedMessage));
            
            await _userService.AddUserAsync(new UserDto
            {
                FirstName = context.Message.FirstName,
                MiddleName = context.Message.MiddleName,
                LastName = context.Message.LastName,
                Email = context.Message.Email,
                PhoneNumber = context.Message.PhoneNumber
            });
        }
    }
}
