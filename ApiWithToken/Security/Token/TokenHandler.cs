﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApiWithToken.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            var accessTokenExpiration =  DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            var securityKey = SignHandler.GetSecurityKey(this.tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires:accessTokenExpiration,
                notBefore:DateTime.Now,
                claims:GetClaims(user),
                signingCredentials: signingCredentials 
                );


            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);


            AccessToken accessToken = new AccessToken();
            accessToken.Expiration = accessTokenExpiration; 
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Token = token.ToString();
            return accessToken;
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            return claims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using (var mg = RandomNumberGenerator.Create()) 
            {
                mg.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);
            }

            //  Yukardaki Karmaşık yapı yerine aşağıdaki gibi de kullanılabilir. Fakat aşağıdaki kullanımın tespit edilmesi daha kolay,
            //  return Guid.NewGuid().ToString();
        }

        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
        }
    }
}
