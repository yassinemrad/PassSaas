using AttributeRouting.Web.Http;
using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;

using System.Web.Http;

namespace WebApiMap.Controllers
{
    public class StatApiController : ApiController
    {
         ITasksService us = new TasksService();
        // GET: api/StatApi
        public Dictionary<String, int> Get()
        {
            return us.EtatCount();
          //  return us.listtache().AsQueryable() ;
            
         //   return new string[] { "value1", "value2" };
        }
        // GET: api/StatApi/s
        [Route("api/StatApi/value")]
        [HttpGet]
        public Dictionary<String, Dictionary<String,int>> aa()
        {
            return us.etatCountUser(); ;
            //  return us.listtache().AsQueryable() ;

            //   return new string[] { "value1", "value2" };
        }
        // GET: api/StatApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StatApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StatApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StatApi/5
        public void Delete(int id)
        {
        }
    }
}
