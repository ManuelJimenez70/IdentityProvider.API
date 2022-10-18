namespace IdentityProvaider.API.Commands
{
    public record UpdatePasswordCommand(string email, string newPassword, string password);  
}
