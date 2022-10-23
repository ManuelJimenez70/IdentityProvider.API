using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(RolId Id);
        Task AddRole(Role role);
        Task UpdateRole(Role role);

        //Task<List<Roles>> GetRoles();
    }
}
