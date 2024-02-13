using MotoRider.Core.Services.Interfaces;
using MotoRider.Infrastructure.Database.Core;
using MotoRider.Shared.Models;
using System;

namespace MotoRider.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork(new MotoRiderDbContext());
        }

        public User GetUser(string username, string password)
        {
            User userFromDb = _unitOfWork.Users.GetUserByUsername(username);
            string passwordHash = EncryptionService.CreatePasswordHashWithSaltFromDb(password, userFromDb.PasswordSalt);
            
            User user = _unitOfWork.Users.GetUserByUsernameAndPasswordHash(username, passwordHash);

            return user; 
        }

        public bool InsertUser(UserAuthentication userAuthentication)
        {
            try
            {
                (string passwordHash, string passwordSalt) = EncryptionService.CreatePasswordHashAndSalt(userAuthentication.Password);

                User user = new()
                {
                    Username = userAuthentication.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = userAuthentication.FirstName,
                    LastName = userAuthentication.LastName
                };

                _unitOfWork.Users.Add(user);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
