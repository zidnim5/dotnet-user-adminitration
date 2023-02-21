using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace dotnet_user_adminitration
{
     public class AutoMapperProfile : Profile
     {

          public AutoMapperProfile()
          {
               CreateMap<RegisterUserDto, User>();
               CreateMap<RegisterUserDto, UserDetail>();
               CreateMap<UpdateUserDto, UserDetail>();
               CreateMap<UserDetail, UserDto>();
          }
     }
}