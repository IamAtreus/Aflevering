using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Infrastructure;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.RepositoriesImpl
{
    public class LejerRepository : ILejerRepository
    {
        private readonly DatabaseContext _db;

        public LejerRepository(DatabaseContext db)
        {
            _db = db;
        }

        async Task<Domain.Entities.Lejer> ILejerRepository.GetAsync(int id)
        {
            return await _db.Lejer.AsNoTracking().FirstOrDefaultAsync(a => a.LejerId == id) ?? throw new Exception("Lejer not found");
        }
    }
}
