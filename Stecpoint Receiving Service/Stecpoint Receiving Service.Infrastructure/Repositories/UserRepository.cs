using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stecpoint_Receiving_Service.Common.Pagination;
using Stecpoint_Receiving_Service.Domain.Models;
using Stecpoint_Receiving_Service.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
namespace Stecpoint_Receiving_Service.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public UserRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
            

        }
        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser == null)
                return null;

            _mapper.Map(user, existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }
        public async Task<User> FindByIdAsync(long id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<PagedListHolder<User>> GetPagedByOrganizationAsync(long orgId, int pageNumber, int pageSize)
        {
            return await _context.Users
                .Where(u => u.OrganizationId == orgId)
                .Include(u => u.Organization)
                .ToPagedAsync(pageNumber, pageSize, u => u.Id);
        }
    }
}
