namespace IdentityProvaider.API.Commands
{
    public record CreateProductCommand(string title, string description, string category, string image, int rating, int price);
}
