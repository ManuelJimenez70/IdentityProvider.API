using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(UserId Id);
        Task AddUser(User user);
        Task UpdateUser(User user);
    }
}
