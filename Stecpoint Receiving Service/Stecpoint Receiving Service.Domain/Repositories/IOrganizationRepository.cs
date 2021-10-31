using Stecpoint_Receiving_Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stecpoint_Receiving_Service.Domain.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Organization> FindByIdAsync(long id);
    }
}
