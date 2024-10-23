using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraGreateDivanShop.Database;

namespace UltraGreateDivanShop.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly DivanShopContext _context;

        public AdminController(DivanShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string color, decimal? minPrice, decimal? maxPrice, int? minLength, int? maxLength, int? minWidth, int? maxWidth, int? minBedWidth, int? maxBedWidth, string sortOrder)
        {
            var products = _context.Products.AsQueryable();

            // Filtering
            if (!string.IsNullOrEmpty(color))
            {
                products = products.Where(p => p.ColorTitle.Contains(color));
            }
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }
            if (minLength.HasValue)
            {
                products = products.Where(p => p.Length >= minLength);
            }
            if (maxLength.HasValue)
            {
                products = products.Where(p => p.Length <= maxLength);
            }
            if (minWidth.HasValue)
            {
                products = products.Where(p => p.Width >= minWidth);
            }
            if (maxWidth.HasValue)
            {
                products = products.Where(p => p.Width <= maxWidth);
            }
            if (minBedWidth.HasValue)
            {
                products = products.Where(p => p.BedWidth >= minBedWidth);
            }
            if (maxBedWidth.HasValue)
            {
                products = products.Where(p => p.BedWidth <= maxBedWidth);
            }

            // Sorting
            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Title); // Default sort by Title
                    break;
            }

            return View(await products.ToListAsync());
        }
    }
}
