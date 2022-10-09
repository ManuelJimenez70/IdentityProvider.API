using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.Queries
{
    public class RoleQueries
    {
        private readonly IRoleRepository roleRepository;

        public RoleQueries(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public async Task<Role> GetRoleIdAsync(int id)
        {
            var response = await roleRepository.GetRoleById(RolId.create(id));
            return response;
        }
    }
}
