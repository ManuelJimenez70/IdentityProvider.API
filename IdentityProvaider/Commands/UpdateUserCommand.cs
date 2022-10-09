namespace IdentityProvaider.API.Commands
{
    public record UpdateUserCommand(int id, string email, string name, string lastName, string typeDocument, string document_number, string direction, char state);
}
