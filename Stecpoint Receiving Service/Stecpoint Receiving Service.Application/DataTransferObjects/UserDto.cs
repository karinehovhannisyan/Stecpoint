using System;
using System.Collections.Generic;
using System.Text;

namespace Stecpoint_Receiving_Service.Application.DataTransferObjects
{
    public class UserDto
    {
        public long Id { get; set; }
        public long? OrganizationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
