using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Repositories.Interface
{
    public interface IUserRepository
    {

        void AddUser(User user);
        User FindById(int userId);
        User FindByEmailandPassword(string email, string password);
        void SaveRefreshToken(int userId, string refreshToken);
        User GetUserwithRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user);
    }

}
