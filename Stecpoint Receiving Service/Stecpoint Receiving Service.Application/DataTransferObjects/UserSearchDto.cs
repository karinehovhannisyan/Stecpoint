namespace Stecpoint_Receiving_Service.Application.DataTransferObjects
{
    public class UserSearchDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public long OrganizationId { get; set; }
    }
}
