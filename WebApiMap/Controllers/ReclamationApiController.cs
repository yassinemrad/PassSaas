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
    public class ReclamationApiController : ApiController
    {
        ReclamationService rs = new ReclamationService();
        // GET: api/ReclamationApi
        public IEnumerable<reclamation> GetAll()
        {
            return rs.GetAll();
        }

        // GET: api/ReclamationApi/5
        public IEnumerable<reclamation> GetByUser(int id)
        {
            return rs.GetByUser(id);
        }

        // POST: api/ReclamationApi
        public void Post([FromBody]string value)
        {
            reclamation r = new reclamation();


        }

        // PUT: api/ReclamationApi/5
        public void Put(int id, [FromBody]string value)
        {
            reclamation r = new reclamation();
        }

        // DELETE: api/ReclamationApi/5
        public void Delete(int id)
        {
            reclamation r = rs.GetById(id);
            rs.Delete(r);
        }
        public void Traitement(int id , string mail , string suj)
        {
            reclamation r = rs.GetById(id);
            r.etat = 0;
            rs.Update(r);
            rs.Commit();
        }
        [Route("ApiController/ApiReclamation/NonTraiter")]
        [HttpGet]
        public IEnumerable<reclamation> Traiter()
        {
            return rs.listRecLu();
        }
        [Route("ApiController/ApiReclamation/Traiter")]
        [HttpGet]
        public IEnumerable<reclamation> NonTraiter()
        {
            return rs.listRecNonLu();
        }
    }
}
