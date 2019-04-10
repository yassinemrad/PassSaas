using DataMap.Infrastructure;
using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
 public   class ProjetService : ServicePattern<Projet>, IProjetService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ProjetService() : base(unit)
        {

        }
        public IEnumerable<Projet> listproj()
        {
            var v = GetAll();
            Console.WriteLine(v);
            return v;

        }


        public double categoriebank()
        {
            var v = GetMany(c => c.cathegory == Cathegory.Banking ).Count();

            Console.WriteLine(v);
            var x = GetAll().Count();
            var z = (double)v / x * 100;
            return z ;
        }
        public double categcountsc()
        {
            var sc = GetMany(c => c.cathegory == Cathegory.Statistic).Count();
            Console.WriteLine(sc);
            var x = GetAll().Count();
            var z = (double)sc / x * 100;
            return z  ;
        }
        public double categcounteduc()
        {
            var educ = GetMany(c => c.cathegory == Cathegory.Education).Count();
            var x = GetAll().Count();
            var z = (double)educ / x * 100;
            return z;
        }
        public double categcountcommer()
        {
            var commer = GetMany(c => c.cathegory == Cathegory.Commercial).Count();
            Console.WriteLine(commer);
            var x = GetAll().Count();
            var z = (double)commer / x * 100;
            Console.WriteLine(z);
            return z;
        }
         public double categcountmedic()
            {
                var medic = GetMany(c => c.cathegory == Cathegory.Medical).Count();
                Console.WriteLine(medic);
            var x = GetAll().Count();
            var z = (double)medic / x * 100;
            return z ;
        }
        public double categcountautre()
        {
            var aut = GetMany(c => c.cathegory == Cathegory.Autre).Count();
            Console.WriteLine(aut);
            var x = GetAll().Count();
            var z = (double)aut / x * 100;
            return z;
        }




        public IEnumerable<Projet> listprojet()
        {
            var v = GetAll();

            return v;

        }
        public IEnumerable<Projet> getNonDelivredProject() //obtenir un projet non livré
        {
            return unit.getRepository<Projet>().GetMany(p => p.endDate > DateTime.Now).ToList();

        }
        public IEnumerable<Projet> getDelivredProject() //obtenir un projet livré
        {
            return unit.getRepository<Projet>().GetMany(p => p.endDate <= DateTime.Now).ToList();
        }
        public IEnumerable<Projet> getProjectInDate(DateTime start, DateTime end) //Obtenir la date du projet
        {
            return unit.getRepository<Projet>().GetMany(p => p.startDate >= start && p.endDate <= end).ToList();
        }
        public IEnumerable<Projet> getMostExpensiveProject()             //obtenir le projet le plus cher

        {
            return unit.getRepository<Projet>().GetAll().OrderByDescending(p => p.Budget).Take(3).ToList();
        }
        public IEnumerable<ProjectBudget> Get6MostCostlyProjectsForATeamLeader(TeamLeader e)
        //Obtenez 6 projets les plus chers pour un chef d'équipe
        {
            return GetAll()


                .ToList()
                .OrderByDescending(GP => GP.Budget)
                .Take(6)
                .Select(GP => new ProjectBudget
                {
                    ProjectName = GP.name,
                    Budget = GP.Budget
                }).ToList();
        }

        public float progressProject(int id)
        {
            throw new NotImplementedException();
        }
    }
    [DataContract(IsReference = true)]
    public class ProjectBudget
    {
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public float Budget { get; set; }
    }
}


    

