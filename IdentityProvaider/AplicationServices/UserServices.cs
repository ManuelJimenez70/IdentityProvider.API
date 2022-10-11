﻿using IdentityProvaider.API.Commands;
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

        public UserServices(IUserRepository repository, UserQueries userQueries, IPasswordRepository passwordRepository)
        {
            this.repository = repository;
            this.userQueries = userQueries;
            this.passwordRepository = passwordRepository;
        }

        public async Task HandleCommand(CreateUserCommand createUser)
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

        public async Task<User> GetPerfil(int userId)
        {
            return await userQueries.GetUserIdAsync(userId);
        }
    }
}
