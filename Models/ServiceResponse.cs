using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Models
{
     public class ServiceResponse<T>
     {

          public T? Data { get; set; }
          public string Message { get; set; } = "Ok";
          public bool Success { get; set; } = true;

     }
}