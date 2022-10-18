namespace IdentityProvaider.API.Commands
{
    public record CreateLogUserCommand(int id_edit_user, int id_manager, string ip, string location, string coordinate, string email, string name, string lastName, string typeDocument, string document_number, string direction, char state, string description);

}
