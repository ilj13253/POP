using System.ComponentModel.DataAnnotations;

namespace UltraGreateDivanShop.Domain;

public class Product
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string PreviewImg { get; set; }
    public decimal? Price { get; set; }
    public required Category Category { get; set; }
    public string? ColorTitleProduct { get; set; }
    public required string ColorTitle { get; set; }
    public required string ColorHex { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int BedWidth { get; set; }
    public required List<ProductImg> ProductImgs { get; set; }
    public required List<Order> Orders { get; set; }
}