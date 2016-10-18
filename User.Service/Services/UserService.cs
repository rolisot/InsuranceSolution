using Insurance.Domain.Services;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using Insurance.Domain.Repositories;
using Insurance.Common.Resources;

namespace User.Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public void ChangeInformation(string email, string name)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            throw new NotImplementedException();
        }

        public List<Insurance.Domain.Models.User> GetByRange(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Insurance.Domain.Models.User GetByEmail(string email)
        {
            var user = _repository.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
