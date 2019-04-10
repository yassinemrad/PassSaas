using DomainMap.Entities;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using ServiceMap;

namespace WebMap.Controllers
{
    public class ProjetApiController : ApiController
    {
        IProjetService Ps = new ProjetService();
        [Route("api/ProjetApiController/GetDelivredProjects")]
        [HttpGet]
        public HttpResponseMessage GetDelivredProjects()
        {
            var Projects = Ps.getDelivredProject();
            List<Projet> listp = new List<Projet>();
            foreach (var item in Projects)
            {
                listp.Add(new Projet
                { id = item.id,
                    name = item.name,
                    startDate = item.startDate,
                    endDate = item.endDate,
                    Budget = item.Budget,
                    cathegory = item.cathegory

                });


            }
            if (Projects.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listp);
        }
        
        public IQueryable<Projet> Get()
        {
            List<Projet> list = Ps.GetAll().ToList();
            return list.AsQueryable();
        }

        





        // POST: api/ProjetApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProjetApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProjetApi/5
        public void Delete(int id)
        {
        }
        [Route("api/ProjetApiController/GetMostExpensive")]  /*//http://localhost:21514/api/ProjetApiController/GetMostExpensive*/
        [HttpGet]
        public HttpResponseMessage GetMostExpensive()
        {
            var Projects = Ps.getMostExpensiveProject();
            List<Projet> listp = new List<Projet>();
            foreach (var item in Projects)
            {
                listp.Add(new Projet
                {
                    name = item.name,
                    startDate = item.startDate,
                    endDate = item.endDate,
                    Budget = item.Budget,
                    cathegory = item.cathegory

                });


            }
            if (Projects.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listp);

        }
        [Route("api/ProjetApiController/delete/{id}")]
        [HttpGet]
        public void DeleteProvider(int id)
        {
           Projet p = Ps.GetById(id);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Ps.Delete(p);
            Ps.Commit();
        }
        [Route("api/ProjetApiController/Details/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(int id)
        {
            Projet p = Ps.GetById(id);
            Projet pvm = new Projet()

            {
                

                name = p.name,
                description = p.description,
                Photo=p.Photo,
                startDate = p.startDate,
                endDate = p.endDate,
                Budget = p.Budget,


                cathegory = p.cathegory
            };
            if (p == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, pvm);

        }

    }

}


