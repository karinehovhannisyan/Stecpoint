using Stecpoint_Receiving_Service.Common.Pagination;
using Stecpoint_Receiving_Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AnyAsync(string email);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> FindByIdAsync(long id);
        Task<PagedListHolder<User>> GetPagedByOrganizationAsync(long orgId, int pageNumber, int pageSize);
    }
}
