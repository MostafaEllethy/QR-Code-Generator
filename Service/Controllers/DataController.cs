using ImageMagick;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
   [EnableCors(origins: "*", headers: "*", methods: "*")]
   public class DataController : ApiController
   {
      public string Get(int id)
      {
         return "value";
      }

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
            using (var image = new MagickImage(ms))
            {
               MemoryStream eps = new MemoryStream();
               image.Write(eps, MagickFormat.Eps3);
               response.Content = new ByteArrayContent(eps.ToArray());
               response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
               response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
         }
         return response;
      }
   }
}
