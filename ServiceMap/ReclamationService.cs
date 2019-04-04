
using DataMap.Infrastructure;
using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
   public class ReclamationService : ServicePattern<reclamation>, IReclamationService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ReclamationService():base(unit)
        {

        }
        public IEnumerable<reclamation> listRecNonLu()
        {
            var v = GetMany(t => t.etat.Equals(1));
            return v;

        }
        public IEnumerable<reclamation> listRecLu()
        {
            var v = GetMany(t => t.etat.Equals(0));
            return v;

        }
        public IEnumerable<reclamation> GetByUser(int id)
        {
          var  ls = GetMany(t => t.user.Equals(id));
            return ls;

        }
    }
}
