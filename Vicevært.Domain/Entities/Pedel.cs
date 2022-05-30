using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.Entities
{
    public class Pedel
    {
        //public IServiceProvider? ServiceProvider { get; set; }

        [Key]
        public int PedelId { get; set; }
        public string PedelNavn { get; private set; }
        public int TelefonNr { get; private set; }


    }
}
