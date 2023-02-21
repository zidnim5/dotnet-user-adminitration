using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Models
{
     public class Media
     {
          public int Id { get; set; }
          public string Path { get; set; } = string.Empty;
          public string CreatedAt { get; set; }
          public User User { get; set; }
          public int UserId { get; set; }
     }
}