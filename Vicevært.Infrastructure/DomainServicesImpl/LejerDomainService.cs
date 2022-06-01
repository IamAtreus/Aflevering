using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Domain.DomainServices;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.DomainServicesImpl
{
    public class LejerDomainService : ILejerDomainService
    {
        private readonly DatabaseContext _db;

        public LejerDomainService(DatabaseContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.Lejer> ILejerDomainService.GetExistingLejer(Domain.Entities.Lejer lejer)
        {
            return _db.Lejer.Where(b => b.LejerId != lejer.LejerId).ToList();
        }
    }
}
