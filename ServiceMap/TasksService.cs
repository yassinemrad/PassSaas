using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMap.Infrastructure;

using DomainMap;
using DomainMap.Entities;
using ServicePattern;

namespace ServiceMap
{
   public class TasksService : ServicePattern<Tasks>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public TasksService() : base(ut)

        {
        }

    }
}
