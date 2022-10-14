
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
            Console.WriteLine(user.id_user);
        }

        public async Task<User> GetUserById(UserId Id)
        {
            return await db.Users.FindAsync((int)Id);
        }

        public async Task<List<User>> GetUsersByNum(int numI, int numF)
        {
            var usersToShow = new List<User>();
            for (int i = numI; i <= numF ;i++) {
                var user = await db.Users.FindAsync((int)i);
                if (user != null) {
                    usersToShow.Add(user);
                }
            }
            return usersToShow;
        }

        public async Task UpdateUser(User user)
        {
            db.Update(user);
            db.SaveChanges();
        }
    }
}
