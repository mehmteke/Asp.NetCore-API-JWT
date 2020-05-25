using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiWithToken.Domain;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetUser(int userId)
        {
            userId = 3;
            //IEnumerable<Claim> claims = User.Claims;
            //string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            //UserResponse userResponse = userService.FindById(int.Parse(userId));
            UserResponse userResponse = userService.FindById(userId);
            
            if (userResponse.Success)
            { 
                return Ok(userResponse.user);
            }
            else
            {
                return BadRequest(userResponse.Message);
            } 
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddUser(UserResource user)
        {
            User userNew = mapper.Map<UserResource,User>(user);
            UserResponse userResponse = userService.AddUser(userNew);

            if (userResponse.Success)
            {
               return Ok(userResponse.user);
            }
            else
            {
               return BadRequest(userResponse.Message);
            } 
        }
    }
}