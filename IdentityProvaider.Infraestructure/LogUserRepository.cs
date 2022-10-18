using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Infraestructure
{
    public class LogUserRepository : ILogUserRepository
    {

        DatabaseContext db;
        public LogUserRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddLogUser(LogUser user)
        {
            await db.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task<LogUser> GetLogUserById(LogUserId Id)
        {
            return await db.Log_Users.FindAsync((int)Id);
        }

        public async Task UpdateLogUser(LogUser user)
        {
            db.Update(user);
            db.SaveChanges();
        }
    }
}
