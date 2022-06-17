using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Vicevært.Infrastructure.Database.Account;

namespace Vicevært.Web.Pages.Account
{
    //[Authorize(policy: "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public RegisterModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            //Opret Bruger
            var user = new User
            {
                Email = RegisterViewModel.Email,
                UserName = RegisterViewModel.Email,
                Kategori = RegisterViewModel.Kategori,
                Gade = RegisterViewModel.Gade,
                HusNummer = RegisterViewModel.HusNummer,
                PostNummer = RegisterViewModel.PostNummer,
                By = RegisterViewModel.By,
                Telefon = RegisterViewModel.Telefon,
                BrugerIdNr = RegisterViewModel.BrugerIdNr,

            };

            var claimKategori = new Claim("Kategori", RegisterViewModel.Kategori);

            var result = await this.userManager.CreateAsync(user, RegisterViewModel.Password);
            if (result.Succeeded)
            {
                await this.userManager.AddClaimAsync(user, claimKategori);

                return RedirectToPage("/Account/Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
                return Page();
            }
        }
    }

    public class RegisterViewModel
    {
        [Required]
        [DataType(dataType: DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Indtastet Email ikke tilladt!")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Fornavn")]
        public string ForNavn { get; set; }
        [Required]
        [Display(Name = "Efternavn")]
        public string EfterNavn { get; set; }
        public string Gade { get; set; }
        public string HusNummer { get; set; }
        public string PostNummer { get; set; }
        public string By { get; set; }
        [Required]
        [Display(Name = "Bruger kategori")]
        public string Kategori { get; set; }
        public string Telefon { get; set; }
        [Required]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        public string BrugerIdNr { get; set; }
    }
}
