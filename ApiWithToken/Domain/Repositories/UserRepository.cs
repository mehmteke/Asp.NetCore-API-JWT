using ApiWithToken.Domain.Repositories.Interface;
using ApiWithToken.Security.Token;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TokenOptions tokenOptions;

        public UserRepository(ApiWithTokenDBContext context, IOptions<TokenOptions> options):base(context)
        {
            tokenOptions = options.Value;
        }

        public void AddUser(User user)
        {
            context.User.Add(user);
        }

        public User FindById(int userId)
        {
            return context.User.Find(userId);

        }
        public User FindByEmailandPassword(string email, string password)
        {
            return context.User.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public User GetUserwithRefreshToken(string refreshToken)
        {
            return context.User.FirstOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            User userNew = this.FindById(user.Id);
            userNew.RefreshToken = null;
            userNew.RefreshTokenEndDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = this.FindById(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
        }
    }
}
