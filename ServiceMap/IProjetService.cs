﻿using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
   public interface IProjetService: IServicePattern<Projet>
    {
        IEnumerable<Projet> listproj();
        double categoriebank();
            double categcountmedic();
        double categcountcommer();
        double categcounteduc();
        double categcountsc();
         double categcountautre();




        float progressProject(int id);



        IEnumerable<Projet> getProjectInDate(DateTime start, DateTime end);
        IEnumerable<Projet> getDelivredProject();

        IEnumerable<Projet> getNonDelivredProject();


        IEnumerable<Projet> getMostExpensiveProject();

        IEnumerable<ProjectBudget> Get6MostCostlyProjectsForATeamLeader(TeamLeader e);
    }
}
