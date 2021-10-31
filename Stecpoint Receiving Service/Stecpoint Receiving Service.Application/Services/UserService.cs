using AutoMapper;
using Stecpoint_Receiving_Service.Application.DataTransferObjects;
using Stecpoint_Receiving_Service.Application.Exceptions;
using Stecpoint_Receiving_Service.Common.Pagination;
using Stecpoint_Receiving_Service.Domain.Models;
using Stecpoint_Receiving_Service.Domain.Repositories;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public UserService(
            IUserRepository userRepository,
            IOrganizationRepository organizationRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            if (await _userRepository.AnyAsync(userDto.Email))
                throw new ConflictException("User with this email already exists.");

            var user = _mapper.Map<User>(userDto);
            user = await _userRepository.AddAsync(user);
            
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> LinkToOrganizationAsync(long userId, long orgId)
        {
            var organization = await _organizationRepository.FindByIdAsync(orgId);
            if (organization == null)
                throw new NotFoundException("Organization not found");

            var user = await _userRepository.FindByIdAsync(userId);

            if (user == null)
                throw new NotFoundException("User not found");

            if (user.OrganizationId == orgId)
                throw new BadRequestException("User is already linked to the organization");

            user.OrganizationId = orgId;

            user = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<PagedListHolder<UserDto>> GetPagedByOrganizationAsync(UserSearchDto search)
        {
            var users = await _userRepository.GetPagedByOrganizationAsync(search.OrganizationId, search.PageNumber, search.PageSize);
            return _mapper.Map<PagedListHolder<UserDto>>(users);
        }
    }
}
