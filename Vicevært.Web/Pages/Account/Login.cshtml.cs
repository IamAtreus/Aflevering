using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Vicevært.Infrastructure.Database.Accounts;

namespace Vicevært.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<User> signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty] public LoginViewModel Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await signInManager.PasswordSignInAsync(
                this.Login.Email,
                this.Login.Password,
                this.Login.HuskMig,
                false);
            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "Du er låset ude.");
                }
                else
                {
                    ModelState.AddModelError("Login", "Du er ikke logget ind!");
                }

                return Page();
            }
        }
    }
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Husk Mig")]
        public bool HuskMig { get; set; }

    }
}
