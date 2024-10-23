using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using UltraGreateDivanShop.Database;

namespace UltraGreateDivanShop.Web.Controllers;

public class OrderController(DivanShopContext divanShopContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var orders = await divanShopContext.Orders
            .Where(order => order.IdUser == 1)
            .Include(order => order.Products)
            .ToListAsync();

        return View(orders);
    }

    public async Task<IActionResult> Details()
    {
        var order = await divanShopContext.Orders
            .Include(order => order.Products)
            .FirstOrDefaultAsync(order => order.Id == 5);

        return View(order);
    }
}