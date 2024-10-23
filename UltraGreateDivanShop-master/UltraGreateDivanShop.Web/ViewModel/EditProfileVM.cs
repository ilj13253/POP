using System.ComponentModel.DataAnnotations;

namespace UltraGreateDivanShop.Web.ViewModel
{
    public class EditProfileVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
