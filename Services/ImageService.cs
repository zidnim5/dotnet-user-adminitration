using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Services
{

     public class ImageResponse
     {
          public bool Success { get; set; }
          public string Path { get; set; } = string.Empty;
     }

     public class ImageService : IImagesService
     {

          private readonly IHttpContextAccessor _httpContextAccessor;

          public ImageService(IHttpContextAccessor httpContextAccessor)
          {
               _httpContextAccessor = httpContextAccessor;
          }
          public async Task<ImageResponse> Upload(IFormFile file, ImagesType type)
          {
               ImageResponse response = new ImageResponse { };
               response.Success = false;

               if (file != null && file.Length > 0)
               {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot/Assets/Profile", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                         await file.CopyToAsync(stream);
                    }

                    var imageUrl = GetBaseUrl() + fileName;
                    response.Success = true;
                    response.Path = imageUrl;

               }

               return response;
          }


          public string GetBaseUrl()
          {
               var request = _httpContextAccessor!.HttpContext!.Request;
               // var baseUrl = $"{request.Scheme}://{request.Host.Value}{request.Path}/";
               var baseUrl = $"{request.Scheme}://{request.Host.Value}/Asset?filename=";
               return baseUrl;
          }
     }
}