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
        Task<List<User>> GetUsersByNum(int numI, int numF, State state);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task addRoles(List<Rol_User> rolesList);
        Task<List<object>> getHistoryOfLogState(int id_user);
        Task<string[]> getRolesByIdUser(UserId userId);
        Task updateRolesByUserId(UserId userId, List<Rol_User> rolesList);
        Task<int> GetIdUserByEmail(Email userEmail);
    }
}
