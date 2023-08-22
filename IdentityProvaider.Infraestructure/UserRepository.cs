using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Infraestructure
{
    public class UserRepository : IUserRepository
    {
        DatabaseContext db;

        public UserRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task AddUser(User user)
        {
            await db.AddAsync(user);
            await db.SaveChangesAsync();
        }


        public async Task addRoles(List<Rol_User> rolesList)
        {
            foreach (var role in rolesList)
            {
                await db.AddAsync(role);
            }
            db.SaveChanges();
        }

        public Task<string[]> getRolesByIdUser(UserId userId)
        {
            var query = (from roles in db.Roles
                         join rol_user in db.Rol_User on roles.id_rol equals rol_user.id_rol
                         where rol_user.id_user == userId.value
                         select new { roles }).ToList();

            List<string> rolList = new List<string>();
            if (query.Count() > 0)
            {
                foreach (var rol in query)
                {
                    rolList.Add(rol.roles.name.value);
                }
            }
            return Task.FromResult(rolList.ToArray());
        }

        public async Task<User> GetUserById(UserId Id)
        {
            return await db.Users.FindAsync((int)Id);
        }

        public async Task<List<User>> GetUsersByNum(int numI, int numF, State state)
        {
            var user = db.Users.Where(r => r.state.value == state.value).Skip(numI).Take((numF - numI)).ToList();
            return user;
        }

        public async Task updateRolesByUserId(UserId userId, List<Rol_User> rolesList)
        {
            List<Rol_User> user_rols = db.Rol_User.Where(r => r.id_user == userId.value).ToList();
            db.Rol_User.RemoveRange(user_rols);
            foreach (var role in rolesList)
            {
                await db.AddAsync(role);
            }
            db.SaveChanges();
        }

        public async Task UpdateUser(User user)
        {
            db.Update(user);
            db.SaveChanges();
        }
        public Task<int> GetIdUserByEmail(Email userEmail)
        {
            var id_user = db.Users.Where(m => m.email.value == userEmail.value
                                                  && m.state.value == "Activo")
                                                .Select(m => m.id_user).FirstOrDefault();
            return Task.FromResult(id_user);
        }


        public Task<User> GetUserByEmail(Email userEmail)
        {
            User user = db.Users.Where(r => r.email.value == userEmail.value).FirstOrDefault();
            return Task.FromResult(user);
        }


        

    }
}
