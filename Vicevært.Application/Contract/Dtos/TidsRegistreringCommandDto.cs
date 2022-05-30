using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Domain.Entities;

namespace Vicevært.Application.Contract.Dtos
{
    public class TidsRegistreringCommandDto
    {
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
