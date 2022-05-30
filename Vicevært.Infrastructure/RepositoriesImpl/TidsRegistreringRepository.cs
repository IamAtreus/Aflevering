using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Infrastructure;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.RepositoriesImpl
{
    public class TidsRegistreringRepository : ITidsRegistreringRepository
    {
        private readonly DatabaseContext _db;

        public TidsRegistreringRepository(DatabaseContext db)
        {
            _db = db;
        }
        async Task ITidsRegistreringRepository.AddAsync(Domain.Entities.TidsRegistrering tidsRegistrering)
        {
            _db.TidsRegistrerings.Add(tidsRegistrering);
            await _db.SaveChangesAsync();
        }

        async Task<Domain.Entities.TidsRegistrering> ITidsRegistreringRepository.GetAsync(int tidsRegistreringsid)
        {
            return await _db.TidsRegistrerings.FindAsync(tidsRegistreringsid) ?? throw new Exception("TidsRegistrering not found");
        }

        async Task ITidsRegistreringRepository.SaveAsync(Domain.Entities.TidsRegistrering tidsRegistrering)
        {
            _db.TidsRegistrerings.Update(tidsRegistrering);
            await _db.SaveChangesAsync();
        }
    }
}
