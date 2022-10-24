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

        public async Task<Session> getSesionByUserId(UserId userId)
        {
            Session session = db.InSession.Where(r => r.id_user.value == userId.value).First();            
            return session;
        }

        public async Task<List<Session>> getUsersInSesion()
        {
            List<Session> session = db.InSession.Where(r => r.loginDate.value.AddHours(8) > DateTime.Now).ToList();
            return session;
        }

        public async Task<List<Object>> getUsersInSessionByParams(int top , DateTime init)
        {            
            var session = db.InSession.Where(r => r.loginDate.value < DateTime.Now && r.loginDate.value > init ).Select(m => m.id_user.value).Distinct().ToArray();
            List<Result> result = new List<Result>();         
            foreach (var sessionUser in session)
            {                
                var num = db.InSession.Where(r => r.id_user.value == sessionUser).Count();
                result.Add(new Result(sessionUser, num));                
            }
            result.OrderBy(o => o.total).ToList();
            if(!(top >= result.Count))
            {
                result.RemoveRange(top,(result.Count - top));
            }            
            List<Object> hola = new List<object>(); 
            foreach (var res in result)
            {
                hola.Add(new { idUser = res.id_user, total = res.total });               
            }            
            return hola;
        }

        public class Result
        {
            public int id_user;
            public int total;
            public Result(int id_user, int total)
            {
                this.id_user = id_user;
                this.total = total;
            }
        }
    }
}
