using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnet_user_adminitration.Dtos
{
     public class UpdateUserDto
     {

          [Required]
          [EmailAddress]
          public string Email { get; set; } = string.Empty;
          [Required]
          public string Name { get; set; } = string.Empty;

          [Required]
          public string Address { get; set; } = string.Empty;

          [Required]
          public DateTime date_of_birth { get; set; }

          [Required]
          public Gender Gender { get; set; } = Gender.Male;
     }
}