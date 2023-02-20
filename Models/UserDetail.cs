using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Models
{
     public class UserDetail
     {
          public int Uid { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Address { get; set; } = string.Empty;

          public DateTime date_of_birth { get; set; }

          public Gender Gender { get; set; } = Gender.Male;

          public DateTime CreatedAt { get; set; }
          public User User { get; set; }

     }
}