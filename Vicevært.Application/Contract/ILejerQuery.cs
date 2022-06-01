using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract.Dtos;

namespace Vicevært.Application.Contract
{
    public interface ILejerQuery
    {
        Task<LejerQueryDto?> GetLejerAsync(int id);
        Task<IEnumerable<LejerQueryDto>> GetLejerAsync();
    }
}
