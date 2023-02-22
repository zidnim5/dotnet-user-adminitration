using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_user_adminitration.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_user_adminitration.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class UserController : ControllerBase
     {

          private readonly IUserService _service;

          private readonly IWebHostEnvironment _environment;

          public UserController(IUserService service, IWebHostEnvironment environment)
          {
               _service = service;
               _environment = environment;
          }

          [HttpPost]
          [Route("Register")]
          public async Task<ActionResult<ServiceResponse<string>>> Register(RegisterUserDto newUser)
          {
               if (!ModelState.IsValid)
               {
                    return BadRequest(ModelState);
               }
               return Ok(await _service.Register(newUser));
          }

          [HttpPost]
          [Route("login")]
          public async Task<ActionResult<LoginUserDto>> Login(LoginUserDto credentialUser)
          {

               return Ok(await _service.Login(credentialUser));
          }

          [HttpGet]
          [Route("{email}")]
          public async Task<ActionResult<ServiceResponse<UserDto>>> Get(string email)
          {

               return Ok(await _service.GetProfile(email));
          }


          [HttpPut]
          public async Task<ActionResult<ServiceResponse<UserDto>>> Update(UpdateUserDto updateUser)
          {

               return Ok(await _service.Update(updateUser));
          }

          [HttpPost]
          [Route("Upload")]
          public async Task<ActionResult<ServiceResponse<string>>> Avatar(IFormFile file)
          {
               return await _service.Upload(file);
          }

          [NonAction]
          private string GetFilePath(string ProductCode)
          {
               return this._environment.WebRootPath + "./Assets/Profile/" + ProductCode;
          }

     }
}