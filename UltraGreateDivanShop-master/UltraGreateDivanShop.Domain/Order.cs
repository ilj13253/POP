namespace UltraGreateDivanShop.Domain;

public class Order
{
    public int Id { get; set; }
    public required decimal Price { get; set; }
    public required DateTime PurchaseDate { get; set; }
    public required int IdUser { get; set; }
    public required List<Product> Products { get; set; }
}