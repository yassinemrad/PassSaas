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
    public class ModuleService : ServicePattern<Module>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ModuleService() : base(ut)

        {
        }

    }
}
