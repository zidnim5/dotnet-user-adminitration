using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Helper
{
     public static class UserAuthentication
     {

          private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
          {
               using (var hmac = new System.Security.Cryptography.HMACSHA512())
               {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
               }
          }

          private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
          {
               using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
               {
                    var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computeHash.SequenceEqual(passwordHash);
               }
          }


     }
}