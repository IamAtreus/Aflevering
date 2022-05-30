using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Domain.DomainServices;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.DomainServicesImpl
{
    public class TidsRegistreringDomainService : ITidsRegistreringDomainService
    {
        private readonly DatabaseContext _db;

        public TidsRegistreringDomainService(DatabaseContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.TidsRegistrering> ITidsRegistreringDomainService.GetAllTidsRegistrerings()
        {
            return _db.TidsRegistrerings.ToList();
        }

    }
}
