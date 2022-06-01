using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Contract.Dtos;

namespace Vicevært.Contract
{
    public interface ILejerService
    {

        Task<LejerDto?> GetAsync(int id);
        Task<IEnumerable<LejerDto>> GetAsync();
    }
}
