using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.Entities
{
    public class TidsRegistrering
    {
        [NotMapped]
        public IServiceProvider? ServiceProvider { get; set; }
        public TidsRegistrering(/*IServiceProvider serviceProvider,*/ DateTime start, DateTime end, int pedelId, int rekvisitionsId)
        {
            Start = start;
            End = end;
            PedelId = pedelId;
            RekvisitionsId = rekvisitionsId;
        }

        public TidsRegistrering(IServiceProvider serviceProvider, DateTime start, DateTime end, int pedelId, int rekvisitionsId, int tidsRegistreringsid)
        {
            ServiceProvider = serviceProvider;
            Start = start;
            End = end;
            PedelId = pedelId;
            RekvisitionsId = rekvisitionsId;
            TidsRegistreringsId = tidsRegistreringsid;
        }
        [Key]
        public int TidsRegistreringsId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int PedelId { get; set; }
        public int RekvisitionsId { get; set; }

        [ForeignKey("PedelId")]
        public Pedel Pedel { get; set; }

        [ForeignKey("RekvisitionsId")]
        public Rekvisition Rekvisition { get; set; }
    }
}
