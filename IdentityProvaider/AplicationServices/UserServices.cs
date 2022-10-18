using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.AplicationServices
{
    public class UserServices
    {
        private readonly IUserRepository repository;
        private readonly UserQueries userQueries;
        private readonly IPasswordRepository passwordRepository;
        private readonly ILogUserRepository logRepository;        

        public UserServices(IUserRepository repository, UserQueries userQueries, IPasswordRepository passwordRepository,
            ILogUserRepository logRepository)
        {
            this.repository = repository;
            this.userQueries = userQueries;
            this.passwordRepository = passwordRepository;
            this.logRepository = logRepository;            
        }

        public async Task HandleCommand(CreateUserCommand createUser , string ip)
        {

            var user = new User();
            user.setEmail(Email.create(createUser.email));
            user.setName(UserName.create(createUser.name));
            user.setLastName(UserLastName.create(createUser.lastName));
            user.setTypeDocument(UserTypeDocument.create(createUser.typeDocument));
            user.setIdentification(UserIdentification.create(createUser.document_number));
            user.setDirection(Direction.create(createUser.direction));

            await repository.AddUser(user);
            var securutyPassword = new Password(createUser.email);
            securutyPassword.setPassword(Hash.create(createUser.password));
            await passwordRepository.AddPassword(securutyPassword);


            var log = new LogUser();
            log.setIP(IP.create(ip));
            log.setIdManager(UserId.create(createUser.id_manager));
            log.setIdEditUser(UserId.create(user.id_user));
            log.setEmail(Email.create(createUser.email));
            log.setName(UserName.create(createUser.name));
            log.setLastName(UserLastName.create(createUser.lastName));
            log.setTypeDocument(UserTypeDocument.create(createUser.typeDocument));
            log.setIdentification(UserIdentification.create(createUser.document_number));
            log.setDirection(Direction.create(createUser.direction));
            log.setState(user.state);
            log.setDescription(Description.create("Se crea nuevo usuario"));
            await logRepository.AddLogUser(log);

        }

        public async Task HandleCommand(UpdateUserCommand updateUserCommand)
        {
            var user = new User(UserId.create(updateUserCommand.id));
            user.setEmail(Email.create(updateUserCommand.email));
            user.setName(UserName.create(updateUserCommand.name));
            user.setTypeDocument(UserTypeDocument.create(updateUserCommand.typeDocument));
            user.setLastName(UserLastName.create(updateUserCommand.lastName));
            user.setIdentification(UserIdentification.create(updateUserCommand.document_number));
            user.setDirection(Direction.create(updateUserCommand.direction));
            user.setState(State.create(updateUserCommand.state));
            await repository.UpdateUser(user);




        }

        public async Task HandleCommand(UpdatePasswordCommand updatePassword)
        {
            Password password = await passwordRepository.GetPasswordByHash(Hash.create(updatePassword.email));
            if (password.password.Equals(Hash.create(updatePassword.password))) {
                var securutyPassword = new Password(updatePassword.email);
                securutyPassword.setPassword(Hash.create(updatePassword.newPassword));
                await passwordRepository.UpdatePassword(securutyPassword);
            }

        }

        public async Task<Password> GetPassword(string email)
        {
            return await passwordRepository.GetPasswordByHash(Hash.create(email));
    }

        public async Task<User> GetPerfil(int userId)
        {
            return await userQueries.GetUserIdAsync(userId);
        }

        public async Task<List<User>> GetUsersByNum(int numI, int numF)
        {
            return await userQueries.GetUsersByNum(numI,numF);
        }
    }
}
