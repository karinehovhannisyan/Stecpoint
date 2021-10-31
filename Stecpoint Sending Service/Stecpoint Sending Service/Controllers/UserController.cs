using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stecpoint_Sending_Service.Application.Commands;
using System.Threading.Tasks;

namespace Stecpoint_Sending_Service.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserCommand user)
        {

            await _mediator.Send(user);
            return NoContent();
        }
    }
}
