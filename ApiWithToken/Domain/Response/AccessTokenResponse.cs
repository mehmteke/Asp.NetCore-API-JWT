using ApiWithToken.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Response
{
    public class AccessTokenResponse:BaseResponse
    {
        public AccessToken accessToken { get; set; }

        private AccessTokenResponse(bool success, string message):base(success,message)
        {
        }

        public AccessTokenResponse(AccessToken accessToken) : this(true,"") 
        {
            this.accessToken = accessToken;
        }
        public AccessTokenResponse(string message) : this(false,message)
        {
        }

    }
}
