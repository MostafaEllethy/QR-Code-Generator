using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace Service.Controllers
{
   [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
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
      [HttpGet, Route("eps")]
      public string Data([FromUri] string data)
      {
         return "Ok";
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
