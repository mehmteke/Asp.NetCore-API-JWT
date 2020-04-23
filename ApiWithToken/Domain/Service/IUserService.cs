using ApiWithToken.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Service
{
    public interface IUserService
    {
        UserResponse AddUser(User user);
        UserResponse FindById(int userId);
        UserResponse FindByEmailandPassword(string email, string password);
        void SaveRefreshToken(int userId, string refreshToken);
        UserResponse GetUserwithRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user);
    }
}
