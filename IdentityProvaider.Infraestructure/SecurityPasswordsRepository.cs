using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.Infraestructure
{
    public class SecurityPasswordsRepository : IPasswordRepository
    {
        DatabaseContext db;

        public SecurityPasswordsRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddPassword(Domain.Entities.Password password)
        { 
            await db.AddAsync(password);
            await db.SaveChangesAsync();
        }

        public async Task<Password> GetPasswordByHash(Hash hash)
        {
            return await db.SecurityPasswords.FindAsync(hash.value);
        }

        public async Task UpdatePassword(Password password)
        { 
            db.Update(password);
            db.SaveChanges();
        }
    }

    
}
