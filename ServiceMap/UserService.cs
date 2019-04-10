
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
  public  class UserService : ServicePattern<User>, IUserService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public UserService():base(unit)
        {

        }
        public enum mois {  janvier=1,fevrier=2, mars = 3, avril=4, mai=5,juin=6,juillet=7,aout=8,septembre=9,october=10,novembre=11,decembre=12 }

        public Dictionary<String,int> userdate()
        {
            Dictionary<String, int> dicuser = new Dictionary<string, int>();
            foreach (mois item in Enum.GetValues(typeof(mois)) )
            {
             //   var o = GetMany(t => (int)item == (t.dateEntree.Month)).Count();
                int s = GetMany(t => (int)item == (t.LockoutEndDateUtc.Value.Month)).Count();
                dicuser.Add(item.ToString(), s);
            //    User.Identity.
            }
            return dicuser;
        }
       public User getbyuser(int id)
        {
            UserService userService = new UserService();
           var req = GetById(id);
        //    var x = GetMany(t =>  == t.Roles.ToList());
            return req;
        }
       public string FindMailOfUserById(int id)
        {
            User x = GetById(id);
            return x.Email;
            
        }
        public User finUserByMail(string mail)
        {
        
            var x = GetMany(u => u.Email.Equals(mail));
            return x.FirstOrDefault();
        }

    }
}
