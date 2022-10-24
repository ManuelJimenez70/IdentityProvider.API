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
        Task<Session>getSesionByUserId(UserId Id);

        Task<List<Session>> getUsersInSesion();
        Task<List<Object>> getUsersInSessionByParams(int top, DateTime init);
        Task AddSession(Session sessionUser);
    }
}
