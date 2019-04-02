
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        MyContext DataContext { get; }
    }

}
