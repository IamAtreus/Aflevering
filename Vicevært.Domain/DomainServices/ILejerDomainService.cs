using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.DomainServices
{
    public interface ILejerDomainService
    {
        IEnumerable<Entities.Lejer> GetExistingLejer(Domain.Entities.Lejer lejer);
    }
}
