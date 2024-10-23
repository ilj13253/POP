using Microsoft.AspNetCore.Mvc.Rendering;
using UltraGreateDivanShop.Domain;
using UltraGreateDivanShop.Web.Core;

namespace UltraGreateDivanShop.Web.ViewModel;

public class ProductsListVM
{
    public required int IdCategory { get; set; }
    public required string TitleCategory { get; set; }
    public required string SearchTitle { get; set; }
    public required PaginationList<Product> Products { get; set; }
    public required SelectList Colors { get; set; }
    public required SortProduct? SortProduct { get; set; }
    public required string SearchColor { get; set; }
    public required PaginationList<Product> PaginationList { get; set; }
}