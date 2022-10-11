using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.Domain.Repositories
{
    public interface IPasswordRepository
    {
        Task<Password> GetPasswordByHash(Hash hash);
        Task AddPassword(Password password);

        Task UpdatePassword(Password password);

    }
}
