using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.Queries
{
    public class UserQueries
    {
        private readonly IUserRepository userRepository;

        public UserQueries(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> GetUserIdAsync(int id)
        {
            var response = await userRepository.GetUserById(UserId.create(id));
            return response;
        }
    }
}
