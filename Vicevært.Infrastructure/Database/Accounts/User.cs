using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Infrastructure.Database.Accounts
{
    public class User : IdentityUser
    {
        public string? Kategori { get; set; }
        public string? Gade { get; set; }
        public string? HusNummer { get; set; }
        public string? PostNummer { get; set; }
        public string? By { get; set; }
        public string? Telefon { get; set; }
    }
}
