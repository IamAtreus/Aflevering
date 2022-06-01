using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.Queries
{
    public class LejerQuery : ILejerQuery
    {
        private readonly DatabaseContext _db;

        public LejerQuery(DatabaseContext db)
        {
            _db = db;
        }

        async Task<LejerQueryDto?> ILejerQuery.GetLejerAsync(int id)
        {
            var result = await _db.Lejer.FindAsync(id);
            if (result is null) return new LejerQueryDto();



            return new LejerQueryDto
            {
                LejerId = result.LejerId,
                LejemaalId  = result.LejemaalId ,
                FirstName = result.FirstName,
                MiddleName  = result.MiddleName ,
                LastName = result.LastName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,

            };
        }

        async Task<IEnumerable<LejerQueryDto>> ILejerQuery.GetLejerAsync()
        {
            var result = new List<LejerQueryDto>();
            var dbLejer = await _db.Lejer.ToListAsync();
            dbLejer.ForEach(a => result.Add(new LejerQueryDto
            {
                LejerId = a.LejerId,
                LejemaalId = a.LejemaalId,
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                LastName = a.LastName,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
            }));
            return result;
        }

    }
}
