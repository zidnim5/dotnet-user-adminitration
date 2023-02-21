using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_user_adminitration.Services
{
     public interface IUserService
     {
          Task<ServiceResponse<string>> Login(LoginUserDto credentialUser);
          Task<ServiceResponse<string>> Register(RegisterUserDto newUser);
          Task<ServiceResponse<UserDto>> Update(UpdateUserDto updateUser);
          Task<ServiceResponse<UserDto>> GetProfile(string email);
     }
}