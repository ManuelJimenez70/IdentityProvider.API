using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.AplicationServices
{
    public class RoleServices
    {
        private readonly IRoleRepository repository;
        private readonly RoleQueries roleQueries;

        public RoleServices(IRoleRepository repository, RoleQueries roleQueries)
        {
            this.repository = repository;
            this.roleQueries = roleQueries;
        }

        public async Task HandleCommand(CreateRoleCommand createRole)
        {

            var role = new Role();
            role.setName(RoleName.create(createRole.name));
            role.setDescription(Description.create(createRole.description));
            await repository.AddRole(role);

        }

        public async Task HandleCommand(UpdateRoleCommand updateRoleCommand)
        {
            var role = new Role(RolId.create(updateRoleCommand.id));
            role.setName(RoleName.create(updateRoleCommand.name));
            role.setDescription(Description.create(updateRoleCommand.description));
            await repository.UpdateRole(role);
        }

        public async Task<Role> GetRole(int roleId)
        {
            return await roleQueries.GetRoleIdAsync(roleId);
        }
    }
}
