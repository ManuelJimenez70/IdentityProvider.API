using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;

namespace IdentityProvaider.API.AplicationServices
{
    public class LogUserServices
    {
        private readonly ILogUserRepository repository;
        private readonly LogUserQueries logUserQueries;

        public LogUserServices(ILogUserRepository repository, LogUserQueries logUserQueries)
        {
            this.repository = repository;
            this.logUserQueries = logUserQueries;
        }

        public async Task HandleCommand(CreateLogUserCommand createLogUser)
        {
            var logUser = new LogUser();

            logUser.setIdEditUser(UserId.create(createLogUser.id_edit_user));
            logUser.setIdManager(UserId.create(createLogUser.id_manager));
            logUser.setIP(IP.create(createLogUser.ip));
            logUser.setLocation(Location.create(createLogUser.location));
            logUser.setCoordinate(Coordinate.create(createLogUser.coordinate));
            logUser.setEmail(Email.create(createLogUser.email));
            logUser.setName(UserName.create(createLogUser.name));
            logUser.setLastName(UserLastName.create(createLogUser.lastName));
            logUser.setTypeDocument(UserTypeDocument.create(createLogUser.typeDocument));
            logUser.setIdentification(UserIdentification.create(createLogUser.document_number));
            logUser.setState(State.create(createLogUser.state));
            logUser.setDirection(Direction.create(createLogUser.direction));
            logUser.setDescription(Description.create(createLogUser.description));
            await repository.AddLogUser(logUser);
        }

        public async Task HandleCommand(UpdateLogUserCommand updateLogUserCommand)
        {
            var logUser = new LogUser(LogUserId.create(updateLogUserCommand.id_log), UserId.create(updateLogUserCommand.id_edit_user), UserId.create(updateLogUserCommand.id_manager));
            logUser.setIP(IP.create(updateLogUserCommand.ip));
            logUser.setLocation(Location.create(updateLogUserCommand.location));
            logUser.setCoordinate(Coordinate.create(updateLogUserCommand.coordinate));
            logUser.setEmail(Email.create(updateLogUserCommand.email));
            logUser.setName(UserName.create(updateLogUserCommand.name));
            logUser.setLastName(UserLastName.create(updateLogUserCommand.lastName));
            logUser.setTypeDocument(UserTypeDocument.create(updateLogUserCommand.typeDocument));
            logUser.setIdentification(UserIdentification.create(updateLogUserCommand.document_number));
            logUser.setState(State.create(updateLogUserCommand.state));
            logUser.setDirection(Direction.create(updateLogUserCommand.direction));
            logUser.setDescription(Description.create(updateLogUserCommand.description));
            await repository.UpdateLogUser(logUser);
        }

        public async Task<LogUser> GetPerfil(int userId)
        {
            return await logUserQueries.GetLogUserIdAsync(userId);
        }

    }
}
