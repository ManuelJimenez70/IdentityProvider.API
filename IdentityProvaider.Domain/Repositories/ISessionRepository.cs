using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Repositories
{
    public interface ISessionRepository
    {
        Task<DateTime[]> GetSessionByUserId(UserId Id);
        Task AddSession(Session sessionUser);
    }
}
