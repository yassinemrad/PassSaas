using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class RecController : ApiController
    {
        ReclamationService rs = new ReclamationService();
        [Route("api/Rec/ind")]
        [HttpGet]
        public IEnumerable<reclamation> ind()
        {
            return rs.GetAll();
        }
    }
}
