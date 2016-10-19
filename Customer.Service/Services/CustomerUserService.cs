using Insurance.Common.Resources;
using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using System;

namespace Customers.Service.Services
{
    public class CustomerUserService : ICustomerUserService
    {
        private ICustomerUserRepository _repository;

        public CustomerUserService(ICustomerUserRepository repository)
        {
            this._repository = repository;
        }


        public void Create(string email, string password, string confirmPassword)
        {
            var hasUser = _repository.Get(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new CustomerUser(email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public CustomerUser GetByEmail(string email)
        {
            var user = _repository.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }
    }
}
