using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
 public   interface IUserService: IServicePattern<User>
    {
        Dictionary<String, int> userdate();
    }
}
