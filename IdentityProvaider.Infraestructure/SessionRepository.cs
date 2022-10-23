using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Infraestructure
{
    public class SessionRepository : ISessionRepository
    {
        DatabaseContext db;

        public SessionRepository(DatabaseContext db) { 
            this.db = db;
        }
        public async Task AddSession(Session sessionUser)
        {
            await db.AddAsync(sessionUser);
            await db.SaveChangesAsync();
        }

        public Task<DateTime[]> GetSessionByUserId(UserId userId)
        {
            var query = (from sessions in db.InSession
                         where sessions.id_user.value == userId.value
                         select new { sessions }).ToList();

            List<DateTime> sessionList = new List<DateTime>();
            if (query.Count() > 0)
            {
                foreach (var session in query)
                {
                    sessionList.Add(session.sessions.loginDate.value);
                }
            }
            return Task.FromResult(sessionList.ToArray());
        }
    }
}
