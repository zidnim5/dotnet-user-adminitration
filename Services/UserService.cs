using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace dotnet_user_adminitration.Services
{
     public class UserService : IUserService
     {

          private readonly DataContext _contex;
          private readonly IMapper _mapper;

          private readonly IConfiguration _config;

          private readonly IImagesService _image;

          public UserService(DataContext context, IMapper mapper, IConfiguration config, IImagesService image)
          {
               _contex = context;
               _mapper = mapper;
               _config = config;
               _image = image;
          }

          public async Task<ServiceResponse<string>> Login(LoginUserDto credentialUser)
          {
               ServiceResponse<string> response = new ServiceResponse<string>();

               var user = await _contex.User.FirstOrDefaultAsync(p => p.Email.ToLower().Equals(credentialUser.Email.ToLower()));
               if (user == null)
               {
                    response.Message = "User not found";
                    response.Success = false;
               }
               else if (!VerifyPasswordHash(credentialUser.Password, user.PasswordHash, user.PasswordSalt))
               {
                    response.Message = "Your password or email not match";
                    response.Success = false;
               }
               else
               {
                    response.Message = "Here u are";
                    response.Success = true;
               }

               return response;
          }

          public async Task<ServiceResponse<string>> Register(RegisterUserDto newUser)
          {
               ServiceResponse<string> response = new ServiceResponse<string>();

               if (await UserExists(newUser.Email))
               {
                    response.Success = false;
                    response.Message = "User already exists.";
                    return response;
               }

               User user = _mapper.Map<User>(newUser);

               CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

               user.PasswordHash = passwordHash;
               user.PasswordSalt = passwordSalt;
               user.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd H:m:s");

               _contex.User.Add(user);
               await _contex.SaveChangesAsync();

               response.Data = $"{user.Id}";

               return response;
          }

          public async Task<ServiceResponse<UserDto>> GetProfile(string email)
          {

               ServiceResponse<UserDto> response = new ServiceResponse<UserDto>();

               var user = await _contex.User.Include(c => c.UserDetail).FirstOrDefaultAsync(p => p.Email.ToLower().Equals(email.ToLower()));

               if (user == null)
               {
                    response.Message = "User not found";
                    response.Success = false;
                    return response;
               }

               response.Data = _mapper.Map<UserDto>(user.UserDetail) ?? new UserDto { };

               return response;
          }

          public async Task<ServiceResponse<UserDto>> Update(UpdateUserDto updateUser)
          {
               ServiceResponse<UserDto> response = new ServiceResponse<UserDto>();

               var user = await _contex.User.Include(c => c.UserDetail).FirstOrDefaultAsync(p => p.Email.ToLower().Equals(updateUser.Email.ToLower()));
               if (user == null)
               {
                    response.Message = "User not found";
                    response.Success = false;

                    return response;
               }
               else if (user.UserDetail == null)
               {
                    UserDetail userDetail = new UserDetail { };
                    _mapper.Map(updateUser, userDetail);
                    userDetail.UserId = user.Id;
                    userDetail.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd H:m:s");

                    _contex.UserDetail.Add(userDetail);
               }
               else
               {
                    user.UserDetail.Name = updateUser.Name;
                    user.UserDetail.Address = updateUser.Address;
                    user.UserDetail.Gender = updateUser.Gender;
                    user.UserDetail.date_of_birth = updateUser.date_of_birth;
                    user.UserDetail.Gender = updateUser.Gender;
               }

               await _contex.SaveChangesAsync();
               response.Data = _mapper.Map<UserDto>(user.UserDetail);

               return response;
          }

          private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
          {
               using (var hmac = new System.Security.Cryptography.HMACSHA512())
               {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
               }
          }

          private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
          {
               using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
               {
                    var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computeHash.SequenceEqual(passwordHash);
               }
          }


          public async Task<bool> UserExists(string email)
          {
               if (await _contex.User.AnyAsync(u => u.Email.ToLower() == email.ToLower()))
               {
                    return true;
               }

               return false;
          }

          public async Task<ServiceResponse<string>> Upload(IFormFile file)
          {
               ServiceResponse<string> response = new ServiceResponse<string>();

               ImagesType type = ImagesType.profile;

               string processUpload = await _image.Upload(file, type);

               response.Data = processUpload;


               return response;
          }
     }

}