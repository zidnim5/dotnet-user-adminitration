using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnet_user_adminitration.Dtos
{
     public class LoginUserDto
     {

          [Required]
          [EmailAddress]
          public string Email { get; set; } = string.Empty;

          [Required]
          public string Password { get; set; } = string.Empty;
     }
}