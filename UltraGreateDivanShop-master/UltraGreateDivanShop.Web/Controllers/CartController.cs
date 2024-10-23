using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraGreateDivanShop.Database;
using UltraGreateDivanShop.Domain;
using UltraGreateDivanShop.Web.Repositories.Extensions;
using UltraGreateDivanShop.Web.Repositories.Interfaces;

namespace UltraGreateDivanShop.Web.Controllers;

public class CartController(IRepositoryCart repositoryCart, DivanShopContext divanShopContext) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Add(int id)
    {
        var product = await divanShopContext.Products.SingleOrDefaultAsync(product => product.Id == id) ??
            throw new NullReferenceException();

        repositoryCart.Add(id, product);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(int id)
    {
        repositoryCart.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> PlaceOrder()
    {
        var products = new List<Product>();

        foreach (var id in repositoryCart.Ids())
        {
            var product = await divanShopContext.Products.SingleOrDefaultAsync(product => product.Id == id)
                ?? throw new NullReferenceException();

            products.Add(product);
        }

        var order = new Order
        {
            Price = repositoryCart.Price,
            IdUser = 1,
            PurchaseDate = DateTime.Now,
            Products = products,
        };

        repositoryCart.Clear();

        await divanShopContext.Orders.AddAsync(order);
        await divanShopContext.SaveChangesAsync();


        return RedirectToAction(nameof(Index), nameof(HomeController).GetNameController());
    }
}