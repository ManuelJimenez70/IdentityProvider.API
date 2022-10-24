using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityProvaider.API.AplicationServices
{
    //[Authorize]
    public class UserServices
    {
        private readonly IUserRepository repository;
        private readonly UserQueries userQueries;
        private readonly IPasswordRepository passwordRepository;
        private readonly ILogUserRepository logRepository;
        private readonly ISessionRepository sessionRepository;
        private IConfiguration config;

        public UserServices(IUserRepository repository, UserQueries userQueries, IPasswordRepository passwordRepository,
            ILogUserRepository logRepository, ISessionRepository sessionRepository, IConfiguration config)
        {
            this.repository = repository;
            this.userQueries = userQueries;
            this.passwordRepository = passwordRepository;
            this.logRepository = logRepository;
            this.sessionRepository = sessionRepository;
            this.config = config;
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


            List<Rol_User> listRol = new List<Rol_User>();
            foreach (int rol in createUser.roles)
            {
                listRol.Add(new Rol_User(user.id_user, rol));
            }
            await repository.addRoles(listRol);

            var securityPassword = new Password(createUser.email);
            securityPassword.setPassword(Hash.create(createUser.password));
            await passwordRepository.AddPassword(securityPassword);

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

        public async Task HandleCommand(UpdateUserCommand updateUserCommand,string ip)
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

            var log = new LogUser();
            log.setIP(IP.create(ip));
            log.setIdManager(UserId.create(updateUserCommand.id_manager));
            log.setIdEditUser(UserId.create(user.id_user));
            log.setEmail(Email.create(updateUserCommand.email));
            log.setName(UserName.create(updateUserCommand.name));
            log.setLastName(UserLastName.create(updateUserCommand.lastName));
            log.setTypeDocument(UserTypeDocument.create(updateUserCommand.typeDocument));
            log.setIdentification(UserIdentification.create(updateUserCommand.document_number));
            log.setDirection(Direction.create(updateUserCommand.direction));
            log.setState(user.state);
            string data = string.IsNullOrEmpty(updateUserCommand.description) ? "Se actualiza usuario" : updateUserCommand.description;
            log.setDescription(Description.create(data));
            await logRepository.AddLogUser(log);
        }

        public async Task<string> HandleCommand(UpdatePasswordCommand updatePassword)
        {
            Password password = await passwordRepository.GetPasswordByHash(Hash.create(updatePassword.email));
            if (password != null)
            {
                if (password.password.value.SequenceEqual(Hash.create(updatePassword.password).value))
                {
                    password.setPassword(Hash.create(updatePassword.newPassword));                    
                    await passwordRepository.UpdatePassword(password);
                    return "se actualizo contraseña para el usuario: " + updatePassword.email;
                }
            }
            return "Usuario inexistente";
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

        public async Task<string[]> GetRolesByIdUser(int id_user)
        {
            string[] roles = await userQueries.getRolesByIdUser(id_user);           
            return roles;
        }

        public async Task<DateTime[]> GetSessionsByIdUser(int id_user)
        {
            DateTime[] sessions = await sessionRepository.GetSessionByUserId(UserId.create(id_user));
            return sessions;
        }

        public async Task<string> HandleCommand(LoginCommand loginCommand)
        {           
            Password login = await passwordRepository.GetPasswordByHash(Hash.create(loginCommand.email));            
            if (login != null)
            {
                if (login.password.value.SequenceEqual(Hash.create(loginCommand.password).value))
                {
                    int id_user = await repository.GetIdUserByEmail(Email.create(loginCommand.email));
                    if (id_user == 0)
                    {                      
                        return "El usuario No se encuentra con estado Activo";
                    }
                    var session = new Session(UserId.create(id_user));
                    await sessionRepository.AddSession(session);

                    string[] roles = await userQueries.getRolesByIdUser(id_user);                                     
                    return generateToken(roles, "login@login", id_user);
                }               
                return "Contraseña incorrecta";
            }                       
            return "Usuario no encontrado";
        }
        private string generateToken(string[] roles, string email, int id_user)
        {

            List<Claim> claimList = new List<Claim>();
            foreach (string role in roles)
            {
                claimList.Add(new Claim("roles", role));
            }
            claimList.Add(new Claim("email", email));
            claimList.Add(new Claim("id", id_user.ToString()));

            var claims = claimList.ToArray();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                                     claims: claims,
                                     expires: DateTime.Now.AddHours(8),
                                     signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
