using System;
using System.Collections.Generic;
using System.Text;

namespace Stecpoint_Receiving_Service.Domain.Models
{
    public class Organization
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; }

        public Organization() {}
    }
}
