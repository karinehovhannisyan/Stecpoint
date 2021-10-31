using Stecpoint_Receiving_Service.Application.DataTransferObjects;
using Stecpoint_Receiving_Service.Common.Pagination;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> AddUserAsync(UserDto user);

        Task<UserDto> LinkToOrganizationAsync(long userId, long orgId);

        Task<PagedListHolder<UserDto>> GetPagedByOrganizationAsync(UserSearchDto search);
    }
}
