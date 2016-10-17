using Insurance.Common.Resources;
using Insurance.Common.Validation;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System;

namespace Security.Service.Services
{
    public class SecurityService : ISecurityService
    {
        private ISecurityRepository _repository;

        public SecurityService(ISecurityRepository repository)
        {
            this._repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != PasswordValidation.Encrypt(password))
                throw new Exception(Errors.InvalidCredentials);

            return user;
        }

        public User GetByEmail(string email)
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
