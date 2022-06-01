using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Contract.Dtos
{
    public class LejerQueryDto
    {
        public int LejerId { get; set; }

        public int LejemaalId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
