using ApiWithToken.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Service
{
    public interface IAuthenticationService
    {
        AccessTokenResponse CreateAccessToken(string email, string password);
        AccessTokenResponse CreareAccessTokenWithRefreshToken(string refreshToken);
        AccessTokenResponse RemoveAccessToken(string refreshToken);
    }
}
