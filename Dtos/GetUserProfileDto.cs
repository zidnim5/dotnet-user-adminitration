using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnet_user_adminitration.Dtos
{
     public class GetUserProfileDto
     {

          [Required]
          [EmailAddress]
          public string Email { get; set; } = string.Empty;
     }
}