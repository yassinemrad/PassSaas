using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMap.Controllers
{
    public class ReclamationController : ApiController
    {
        // GET: api/Reclamation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reclamation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reclamation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reclamation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reclamation/5
        public void Delete(int id)
        {
        }
    }
}
