using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Pages.Lejer
{
    [Authorize(policy: "Admin")]
    [Authorize(policy: "Vicevært")]
    [Authorize(policy: "Beboer")]

    public class IndexModel : PageModel
        {
            private readonly ILejerService _lejerService;

            public IndexModel(ILejerService lejerService)
            {
                _lejerService = lejerService;
            }



            [BindProperty] public IEnumerable<LejerIndexModel> Lejer { get; set; } = Enumerable.Empty<LejerIndexModel>();

            public async Task OnGetAsync()
            {
                var lejer = new List<LejerIndexModel>();
                var dbLejer = await _lejerService.GetAsync();
                dbLejer.ToList().ForEach(a => lejer.Add(new LejerIndexModel(a)));
                Lejer = lejer;

            }



            public class LejerIndexModel
            {
                public LejerIndexModel(LejerDto lejer)
                {
                LejerId = lejer.LejerId;
                LejemaalId = lejer.LejemaalId;
                FirstName = lejer.FirstName;
                MiddleName = lejer.MiddleName;
                LastName = lejer.LastName; 
                Email = lejer.Email;
                PhoneNumber = lejer.PhoneNumber;
                }

                public int LejerId { get; set; }

                public int LejemaalId { get; set; }

                public string FirstName { get; set; }

                public string MiddleName { get; set; }

                public string LastName { get; set; }

                public string Email { get; set; }

                public string PhoneNumber { get; set; }
            }
        }
}
