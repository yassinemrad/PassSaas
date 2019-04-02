
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MyContext dataContext;
        public MyContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new MyContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
