using ApiWithToken.Domain;
using ApiWithToken.Domain.Repositories.Interface;
using ApiWithToken.Domain.Response;
using ApiWithToken.Domain.Service;
using ApiWithToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public UserResponse AddUser(User user)
        {
            try
            {
                userRepository.AddUser(user);
                unitOfWork.Complete();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullnaıcı Eklenirken alınana Hata: {ex.Message.ToString()}"); 
            }
        }

        public UserResponse FindByEmailandPassword(string email, string password)
        {
            try
            {
                User user = userRepository.FindByEmailandPassword(email, password);
                if(user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı");
                }
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı Bulunurken Alınan Hata: {ex.Message.ToString()}");
            }
        }

        public UserResponse FindById(int userId)
        {
            try
            {
                User user = userRepository.FindById(userId);
                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı");
                }
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı Bulunurken Alınan Hata: {ex.Message.ToString()}");
            }
        }

        public UserResponse GetUserwithRefreshToken(string refreshToken)
        {
            try
            {
                User user = userRepository.GetUserwithRefreshToken(refreshToken);
                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı");
                }
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Kullanıcı Bulunurken Alınan Hata: {ex.Message.ToString()}");
            }
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                userRepository.RemoveRefreshToken(user);
                unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                 // Loglama
            }
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                userRepository.SaveRefreshToken(userId,refreshToken);
                unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                 // Loglama
            }
        }
    }
}
