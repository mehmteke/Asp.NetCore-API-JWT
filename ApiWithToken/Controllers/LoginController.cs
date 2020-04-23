using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Extensions;
using ApiWithToken.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrors());
            }
            else
            {
                AccessTokenResponse  accessTokenResponse = authenticationService.CreateAccessToken(loginResource.Email,loginResource.Password);

                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.accessToken);
                }
                else
                {
                    return BadRequest(accessTokenResponse.Message);
                }
            } 
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
            AccessTokenResponse accessTokenResponse = authenticationService.CreareAccessTokenWithRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.accessToken);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            } 
        }

        [HttpPost]
        public IActionResult RemoveRefreshToken(TokenResource tokenResource)
        {
           AccessTokenResponse accessTokenResponse =  authenticationService.RemoveAccessToken(tokenResource.RefreshToken);
            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.accessToken);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            } 
        }
             
    }
}