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
        [Route("api/ApiReclamation/Create")]
        [HttpPost]
        public IHttpActionResult Create(reclamation rec)
        {
            if (rec.etat.Equals("") || rec.description.Equals("") || rec.user.Equals(0))

                return BadRequest("Invalid data.");
            else
            {
                reclamation r = new reclamation();
                r.etat = 1;
                r.objet = rec.objet;
                r.description = rec.description;
                r.date = DateTime.Now.ToString("dd-MM-yyyy");
                r.user = rec.user;
                rs.Add(r);
                rs.Commit();
                return Ok("Create Success");
            }
        }
        [Route("api/ApiReclamation/Update")]
        [HttpPut]
        public IHttpActionResult Update(reclamation rec)
        {
            if (rec.etat.Equals("") || rec.description.Equals("") || rec.id.Equals(0))

                return BadRequest("Invalid data.");
            else
            {
                reclamation r = rs.GetById(rec.id);

                r.objet = rec.objet;
                r.description = rec.description;


                rs.Update(r);
                rs.Commit();
                return Ok("Update Success");
            }
        }
        [Route("api/ApiReclamation/GetAll")]
        [HttpGet]
        // GET: api/ReclamationApi
        public IEnumerable<reclamation> GetAll()
        {
            return rs.GetAll();
        }

        [Route("api/ApiReclamation/GetByU")]
        [HttpGet]
        // GET: api/ReclamationApi/5
        public IEnumerable<reclamation> GetByUser(int id)
        {
            return rs.GetByUser(id);
        }

     

        // PUT: api/ReclamationApi/5
        public void Put(int id, [FromBody]string value)
        {
            reclamation r = new reclamation();
        }

        // DELETE: api/ReclamationApi/5
        [Route("api/ApiReclamation/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            reclamation r = rs.GetById(id);
            rs.Delete(r);
            rs.Commit();
            return Ok("success");
        }
        [Route("api/ApiReclamation/Traitement/{id}")]
        [HttpGet]
        public void Traitement(int id , string mail , string suj)
        {
            reclamation r = rs.GetById(id);
            r.etat = 0;
            rs.Update(r);
            rs.Commit();
        }
        [Route("api/ApiReclamation/Traiter")]
        [HttpGet]
        public IEnumerable<reclamation> Traiter()
        {
            return rs.listRecLu();
        }
        [Route("api/ApiReclamation/NonTraiter")]
        [HttpGet]
        public IEnumerable<reclamation> NonTraiter()
        {
            return rs.listRecNonLu();
        }

    }
}
