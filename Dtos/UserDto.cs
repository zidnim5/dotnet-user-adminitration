using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Dtos
{
     public class UserDto
     {
          public string Name { get; set; }
          public string Address { get; set; }

          public DateTime? date_of_birth { get; set; }

          public Gender? Gender { get; set; }
     }
}