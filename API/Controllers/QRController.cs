using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class QRController : ControllerBase
   {
      [HttpPost("Eps")]
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>")]
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
      public IActionResult GenerateEps(Eps model)
      {
         var data = model.Svg.Replace(" ", "+").Replace("_", "/").Replace("-", "+");
         int mod4 = data.Length % 4;
         if (mod4 > 0)
         {
            data += new string('=', 4 - mod4);
         }
         byte[] bytes = Convert.FromBase64String(data);
         //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
         MemoryStream eps = new MemoryStream();
         using (MemoryStream ms = new MemoryStream(bytes))
         {
            using var image = new MagickImage(ms);
            image.Write(eps, MagickFormat.Eps3);
         }
         return File(eps.ToArray(), "application/octet-stream");
      }
   }
}