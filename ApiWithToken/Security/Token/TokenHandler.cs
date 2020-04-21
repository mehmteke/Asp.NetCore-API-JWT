using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithToken.Domain;
using Microsoft.Extensions.Options;

namespace ApiWithToken.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions tokenOptions;
        public TokenHandler(IOptions<TokenOptions> options)
        {
            this.tokenOptions = options.Value;
        }
        public AccessToken CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public void RevokeRefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
