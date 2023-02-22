using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Repositories
{
     public interface IAuthRepository
     {
          string CreateToken(User user);
     }
}