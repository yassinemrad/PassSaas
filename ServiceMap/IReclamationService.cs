
using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
  public   interface IReclamationService : IServicePattern<reclamation>
    {
        IEnumerable<reclamation> listRecLu();
        IEnumerable<reclamation> listRecNonLu();
        IEnumerable<reclamation> GetByUser(int id);
    }
}
