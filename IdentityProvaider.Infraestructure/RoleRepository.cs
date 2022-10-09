using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Infraestructure
{
    public class RoleRepository: IRoleRepository
    {
        DatabaseContext db;

        public RoleRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddRole(Role role)
        {
            await db.AddAsync(role);
            await db.SaveChangesAsync();
            Console.WriteLine(role.id_rol);
        }

        public async Task<Role> GetRoleById(RolId Id)
        {
            return await db.Roles.FindAsync((int)Id);
        }

        public async Task UpdateRole(Role role)
        {
            db.Update(role);
            db.SaveChanges();
        }

    }
}
