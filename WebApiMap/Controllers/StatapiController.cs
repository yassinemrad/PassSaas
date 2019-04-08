using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMap.Controllers
{
    public class StatapiController : ApiController
    {

        ITasksService ts = new TasksService();
        IUserService us = new UserService();
        IProjetService ps = new ProjetService();

        // GET: api/Statapi
        public Dictionary<String, int> Get()
        {
            return ts.EtatCount();
            //  return us.listtache().AsQueryable() ;

            //   return new string[] { "value1", "value2" };
        }
        // GET: api/Statapi/s
        [Route("api/Statapi/value")]
        [HttpGet]
        public Dictionary<String, Dictionary<String, int>> etatcountUs()
        {
            return ts.etatCountUser();

        }
        [Route("api/Statapi/etatprogtodo")]
        [HttpGet]
        public double etatprogtodo(int id)
        {
            return ts.EtatProgresstodo(id);

        }

        [Route("api/Statapi/etatprogdoing")]
        [HttpGet]
        public double etatprogdoing(int id = 1)
        {
            return ts.EtatProgresdoing(id);

        }
        [Route("api/Statapi/etatprogdone")]
        [HttpGet]
        public double etatprogdone(int id)
        {
            return ts.EtatProgressdone(id);

        }
        //petit pb modules=0
        [Route("api/Statapi/listtache")]
        [HttpGet]
        public IEnumerable<Tasks> listtache()
        {
            return ts.listtache();

        }
        //erruerrrrrrr
       // /api/Statapi/listta?etat=Doing&id=1
        [Route("api/Statapi/listta")]
        [HttpGet]
        public int listta (Etat etat,int id)
        {
           return ts.listtacs(etat,id);

        }

        [Route("api/Statapi/dateuser")]
        [HttpGet]
        public Dictionary<String, int> dateuser()
        {
            return us.userdate();

        }
        [Route("api/Statapi/userid")]
        [HttpGet]
        public User getbyuser(int id)
        {
            return us.GetById(id);

        }
        [Route("api/Statapi/email")]
        [HttpGet]
        public String getbyemail(int id)
        {
            return us.FindMailOfUserById(id);

        }
        //errruuuurrrr
        [Route("api/Statapi/projlist")]
        [HttpGet]
        public IEnumerable<Projet> listproj()
        {
            return ps.listproj();

        }
        [Route("api/Statapi/categbank")]
        [HttpGet]
        public double categbank()
        {
            return ps.categoriebank();

        }
        [Route("api/Statapi/categsc")]
        [HttpGet]
        public double categsc()
        {
            return ps.categcountsc();

        }
        [Route("api/Statapi/categautre")]
        [HttpGet]
        public double categautre()
        {
            return ps.categcountautre();

        }
        [Route("api/Statapi/categcomm")]
        [HttpGet]
        public double categcomm()
        {
            return ps.categcountcommer();

        }
        [Route("api/Statapi/categeduc")]
        [HttpGet]
        public double categeduc()
        {
            return ps.categcounteduc();

        }
        [Route("api/Statapi/categmedic")]
        [HttpGet]
        public double categmedic()
        {
            return ps.categcountmedic();

        }






    }
}

