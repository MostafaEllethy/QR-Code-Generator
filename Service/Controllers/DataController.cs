using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
      [HttpPost, Route("eps")]
      public HttpResponseMessage Data()
      {
         var data = HttpContext.Current.Request.Params["data"];
         data = data.Replace(" ", "+").Replace("_", "/").Replace("-", "+");
         int mod4 = data.Length % 4;
         if (mod4 > 0)
         {
            data += new string('=', 4 - mod4);
         }

         byte[] bytes = Convert.FromBase64String(data);
         HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
         using (MemoryStream ms = new MemoryStream(bytes))
         {
            Directory.CreateDirectory("Temp");
            var imagePath = Path.Combine("Temp", DateTime.Now.Ticks.ToString()) + ".eps";
            using (var image = new MagickImage(ms))
            {
               image.Write(imagePath, MagickFormat.Eps3);
               response.Content = new ByteArrayContent(File.ReadAllBytes(imagePath));
               response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
               response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
            new Thread(() =>
            {
               Thread.CurrentThread.IsBackground = true;
               DeleteFile(imagePath);
            }).Start();
         }
         return response;
      }

      private void DeleteFile(string path)
      {
         Thread.Sleep(600000);
         File.Delete(path);
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
