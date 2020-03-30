using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace Service.Controllers
{
    public class DataController : ApiController
    {
      // GET: api/Test
      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
      public IEnumerable<string> Get()
        {
         return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public string Post([FromBody]string value, [FromBody]string value2)
        {
         return "True";
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
