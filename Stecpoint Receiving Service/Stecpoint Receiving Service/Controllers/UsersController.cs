using Microsoft.AspNetCore.Mvc;
using Stecpoint_Receiving_Service.Application.DataTransferObjects;
using Stecpoint_Receiving_Service.Application.Services;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{id:long}/organizations/{orgId:long}")]
        public async Task<IActionResult> LinkToOrganizationAsync([FromRoute] long id, [FromRoute] long orgId)
        {
            var user = await _userService.LinkToOrganizationAsync(id, orgId);
            return Ok(user);
        }
        
        [HttpPost("paged")]
        public async Task<IActionResult> GetPagedByOrganizationAsync([FromBody] UserSearchDto search)
        {
            var users = await _userService.GetPagedByOrganizationAsync(search);
            return Ok(users);
        }
    }
}
