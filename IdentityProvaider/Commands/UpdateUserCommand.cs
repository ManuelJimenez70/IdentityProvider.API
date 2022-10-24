namespace IdentityProvaider.API.Commands
{
    public record UpdateUserCommand(int id_manager, int id, string? email, string? name, string? lastName, string? typeDocument, string? document_number, string? direction, string? state ,string? description);
}
