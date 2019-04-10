using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
  public  interface ITasksService : IServicePattern<Tasks>
    {
        Dictionary<String, int> EtatCount(int idProjet);
        IEnumerable<Tasks> listtache();
        int listtacs(Etat e, int idProjet);
        double EtatProgresstodo(int idProjet);
        double EtatProgresdoing(int idProjet);

        double EtatProgressdone(int idProjet);

        Dictionary<String, Dictionary<String, int>> etatCountUser();
    }
}
