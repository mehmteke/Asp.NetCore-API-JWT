using ApiWithToken.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        void RevokeRefreshToken(User user);
    }
}
