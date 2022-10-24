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

        public async Task<List<User>> GetUsersByNum(int numI, int numF ,string state)
        {
            var response = await userRepository.GetUsersByNum(numI,numF, State.create(state));
            return response;
        }
        public async Task<string[]> getRolesByIdUser(int userId)
        {
            var response = await userRepository.getRolesByIdUser(UserId.create(userId));
            return response;
        }

    }
}
