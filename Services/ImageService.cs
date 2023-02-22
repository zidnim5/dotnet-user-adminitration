using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Services
{
     public class ImageService : IImagesService
     {

          private readonly IHttpContextAccessor _httpContextAccessor;

          public ImageService(IHttpContextAccessor httpContextAccessor)
          {
               _httpContextAccessor = httpContextAccessor;
          }
          public async Task<string> Upload(IFormFile file, ImagesType type)
          {
               if (file != null && file.Length > 0)
               {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Profile", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                         await file.CopyToAsync(stream);
                    }

                    var imageUrl = GetBaseUrl() + fileName;

                    return imageUrl;
               }

               return "Oops, Cannot upload file";
          }


          public string GetBaseUrl()
          {
               var request = _httpContextAccessor!.HttpContext!.Request;
               var baseUrl = $"{request.Scheme}://{request.Host.Value}{request.Path}/";
               return baseUrl;
          }
     }
}