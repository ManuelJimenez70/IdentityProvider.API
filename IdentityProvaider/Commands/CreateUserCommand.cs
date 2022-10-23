namespace IdentityProvaider.API.Commands
{
    public record CreateUserCommand(int id_manager, string email,string name, string lastName, string typeDocument, string document_number, string direction, string password, int[] roles);
}
