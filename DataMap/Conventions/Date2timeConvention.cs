using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap.Conventions
{
   public class Date2timeConvention : Convention
    {
        public Date2timeConvention()
        {
            Properties<DateTime>().Configure(t => t.HasColumnType("datetime2"));
        }
    }
}
