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
    public class ForumApiController : ApiController

    {
        ForumService ps = new ForumService();

        // GET: api/ForumApi
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ForumApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ForumApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ForumApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ForumApi/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("forumApi/getAll")]
        public IEnumerable<Forum>Get()
        {
            List<Forum> list = ps.GetAll().ToList();
            return list;
        }
    }
}
