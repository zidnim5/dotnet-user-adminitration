using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Models
{
     public class Media
     {
          public int Uid { get; set; }
          public string Path { get; set; } = string.Empty;
          public DateTime CreatedAt { get; set; }
          public User User { get; set; }

     }
}