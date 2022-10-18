using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Repositories
{
    public interface ILogUserRepository
    {
        Task<LogUser> GetLogUserById(LogUserId Id);
        Task AddLogUser(LogUser logUser);
        Task UpdateLogUser(LogUser logUser);
    }
}
