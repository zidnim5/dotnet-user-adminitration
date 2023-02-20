using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Models
{
     public class User
     {
          public int Uid { get; set; }

          public string Email { get; set; } = string.Empty;

          public string Password { get; set; } = string.Empty;
          public byte[] PasswordHash { get; set; }
          public byte[] PasswordSalt { get; set; }

          public DateTime CreatedAt { get; set; }

     }
}