using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMap.Infrastructure;

using DomainMap.Entities;
using ServicePattern;

namespace ServiceMap
{
   public class TasksService : ServicePattern<Tasks>, ITasksService
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public TasksService() : base(ut)

        {
        }
        public Dictionary<String, int> EtatCount()
        {
            Dictionary<String, int> etatDic = new Dictionary<string, int>();
            var toDoCount = GetMany(t => (t.etat == Etat.ToDo)).Count();
            var doingCount = GetMany(t => (t.etat == Etat.Doing)).Count();
            var doneCount = GetMany(t => (t.etat == Etat.Done)).Count();
            etatDic.Add(Etat.ToDo.ToString(), toDoCount);
            etatDic.Add(Etat.Doing.ToString(), doingCount);
            etatDic.Add(Etat.Done.ToString(), doneCount);
            return etatDic;

        }
        public Dictionary<String, Dictionary<String, int>> etatCountUser()
        {
            Dictionary<String, Dictionary<String, int>> finalDic = new Dictionary<String, Dictionary<string, int>>();

            // get a user list form a user_service
            UserService userservice = new UserService();
            IEnumerable<User> userList = userservice.GetAll();

            foreach (User element in userList)
            {
                Dictionary<String, int> etatDic = new Dictionary<string, int>();
                var toDoCount = GetMany(t => (t.etat == Etat.ToDo) && (t.user.Email == element.Email)).Count();
                var doingCount = GetMany(t => (t.etat == Etat.Doing) && (t.user.Email == element.Email)).Count();
                var doneCount = GetMany(t => (t.etat == Etat.Done) && (t.user.Email == element.Email)).Count();
                // var doneCount = GetMany(t => (t.etat == Etat.done) && (t.user.id == element.id)).Count();
                etatDic.Add(Etat.ToDo.ToString(), toDoCount);
                etatDic.Add(Etat.Doing.ToString(), doingCount);
                etatDic.Add(Etat.Done.ToString(), doneCount);
                finalDic.Add(element.LastName, etatDic);
            }
            return finalDic;
        }
        public double EtatProgresstodo(int idProjet)
        {
            var v = GetMany(t => (t.etat == Etat.ToDo) && (t.modules.projet.id == idProjet)).Count();
            var n = GetMany(t => t.modules.projet.id == idProjet).Count();
            var z = (double)v / n * 100;
            Console.WriteLine(v);
            return z;

        }
        public double EtatProgresdoing(int idProjet)
        {
            var d = GetMany(t => (t.etat == Etat.Doing) && (t.modules.projet.id == idProjet)).Count();
            var n = GetMany(t => t.modules.projet.id == idProjet).Count();
            var z = (double)d / n * 100;
            Console.WriteLine(d);
            return z;

        }
        public double EtatProgressdone(int idProjet)
        {
            var o = GetMany(t => (t.etat == Etat.Done) && (t.modules.projet.id == idProjet)).Count();
            var n = GetMany(t => t.modules.projet.id == idProjet).Count();
            var z = (double)o / n * 100;
            Console.WriteLine(o);
            return z;

        }
        public IEnumerable<Tasks> listtache()
        {
            var v = GetAll();
            Console.WriteLine(v);
            return v;

        }
        public int listtacs(Etat e, int idProjet)
        {
            Etat TODOo = e;
            string str = TODOo.ToString();

            Etat DOINGg = Etat.Doing;
            string str1 = DOINGg.ToString();
            Etat DONEe = Etat.Done;
            string str2 = DONEe.ToString();
            //  var c = GetMany(t => t.etat == str.ToString);
            var c = GetMany(t => t.etat == TODOo).Count();
            var n = GetMany(t => t.modules.projet.id == idProjet).Count();
            var x = (c / n) * 100;


            return x;
            //   return c;

        }


    }

}

