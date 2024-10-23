using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using UltraGreateDivanShop.Database;
using UltraGreateDivanShop.Web.ViewModel;

namespace UltraGreateDivanShop.Web.Views.EditProfile
{
    public class EditProfileModel : PageModel
    {
        private readonly DivanShopContext _context;

        public EditProfileModel(DivanShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditProfileVM Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            Input = new EditProfileVM
            {
                Name = user.FirstName,
                Email = user.Email
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = Input.Name;
            user.Email = Input.Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/Profile");
        }
        public void OnGet()
        {
        }
    }
}
