
using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
    interface IReclamationService
    {
        IEnumerable<reclamation> listRecLu();
        IEnumerable<reclamation> listRecNonLu();
        IEnumerable<reclamation> GetByUser(string id);
    }
}
