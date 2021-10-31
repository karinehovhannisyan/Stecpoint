using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stecpoint_Receiving_Service.Domain.Models;
using Stecpoint_Receiving_Service.Domain.Repositories;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.Infrastructure.Repositories
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public OrganizationRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Organization> FindByIdAsync(long id) 
        {
            return await _context.Organizations.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
