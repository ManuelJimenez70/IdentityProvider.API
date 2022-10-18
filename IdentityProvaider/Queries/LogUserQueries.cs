using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.Queries
{
    public class LogUserQueries
    {
        private readonly ILogUserRepository logUserRepository;

        public LogUserQueries(ILogUserRepository logUserRepository)
        {
            this.logUserRepository = logUserRepository;
        }
        public async Task<LogUser> GetLogUserIdAsync(int id)
        {
            var response = await logUserRepository.GetLogUserById(LogUserId.create(id));
            return response;
        }

    }
}
