using AutoMapper;
using Stecpoint_Receiving_Service.Application.DataTransferObjects;
using Stecpoint_Receiving_Service.Common.Pagination;
using Stecpoint_Receiving_Service.Domain.Models;


namespace Stecpoint_Receiving_Service.Application.Mapping
{
    public class ApplicationMapperProfile: Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            
            CreateMap<OrganizationDto, Organization>()
                .ForMember(o => o.Users, m => m.Ignore())
                .ReverseMap();

            CreateMap(typeof(PagedListHolder<>), typeof(PagedListHolder<>));
        }
    }
}
