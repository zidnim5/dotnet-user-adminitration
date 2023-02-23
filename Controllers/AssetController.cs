using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_user_adminitration.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class AssetController : ControllerBase
     {

          [HttpGet]
          public async Task<IActionResult> Download(string fileName)
          {
               var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "Profile", fileName);
               var memory = new MemoryStream();
               using (var stream = new FileStream(path, FileMode.Open))
               {
                    await stream.CopyToAsync(memory);
               }
               memory.Position = 0;
               return File(memory, "application/octet-stream", fileName);
          }

     }
}