using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace dotnet_user_adminitration.Repositories
{
     public class AuthRepository : IAuthRepository
     {
          private readonly DataContext _context;
          private readonly IConfiguration _configuration;

          public AuthRepository(DataContext context, IConfiguration configuration)
          {
               _context = context;
               _configuration = configuration;
          }

          public string CreateToken(User user)
          {
               List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

               SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                   .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

               SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

               SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
               {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
               };

               JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
               SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

               return tokenHandler.WriteToken(token);
          }
     }
}