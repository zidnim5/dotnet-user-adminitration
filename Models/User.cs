using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnet_user_adminitration.Models
{
     public class User
     {
          public int Id { get; set; }
          public string Email { get; set; } = string.Empty;

          public byte[] PasswordHash { get; set; }
          public byte[] PasswordSalt { get; set; }

          public string CreatedAt { get; set; }

          public UserDetail UserDetail { get; set; }
          public Media Media { get; set; }

     }
}