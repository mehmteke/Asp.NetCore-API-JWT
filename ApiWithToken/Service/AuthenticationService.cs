using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.tokenHandler = tokenHandler;
            this.userService = userService;
        }


        public AccessTokenResponse CreareAccessTokenWithRefreshToken(string refreshToken)
        {
            UserResponse userResponse = userService.GetUserwithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                if(userResponse.user.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);
                    userService.SaveRefreshToken(userResponse.user.Id, accessToken.RefreshToken);
                    return new AccessTokenResponse(accessToken);
                }
                else
                {
                    return new AccessTokenResponse($"AccessToken'ın Süresi Dolmuştur.");
                }
            }
            else
            {
                return new AccessTokenResponse("RefreshToken Bulunamadı.");
            }
        }

        public AccessTokenResponse CreateAccessToken(string email, string password)
        {
            UserResponse userResponse = userService.FindByEmailandPassword(email, password);

            if (userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);
                userService.SaveRefreshToken(userResponse.user.Id, accessToken.RefreshToken);
                return new AccessTokenResponse(accessToken);
            }
            else
            {
                return new AccessTokenResponse(userResponse.Message);
            }
        }

        public AccessTokenResponse RemoveAccessToken(string refreshToken)
        {
            UserResponse userResponse = userService.GetUserwithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                userService.RemoveRefreshToken(userResponse.user);
                return new AccessTokenResponse(new AccessToken());
            }
            else
            {
                return new AccessTokenResponse($"RefreshToken Bulunamadı.");
            }
        }
    }
}
