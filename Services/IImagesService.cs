using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Services
{
     public interface IImagesService
     {
          Task<string> Upload(IFormFile file, ImagesType type);
     }
}