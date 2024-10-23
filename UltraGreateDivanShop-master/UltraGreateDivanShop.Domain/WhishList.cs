namespace UltraGreateDivanShop.Domain;

public class WhishList
{
    public int Id { get; set; }
    public required int IdUser { get; set; }
    public required Product Product { get; set; }
}