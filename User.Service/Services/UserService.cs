﻿using Insurance.Domain.Services;
using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using Insurance.Domain.Repositories;
using Insurance.Common.Resources;

namespace UsersService.Services
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

        public List<User> GetByRange(int skip, int take)
        {
            return this._repository.GetByRange(skip, take);
        }

        public void Create(string email, string password, string confirmPassword)
        {
            var hasUser = _repository.GetByEmail(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new User(email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public string ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            var user = _repository.GetByEmail(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public User GetById(string id)
        {
            return this._repository.GetById(Guid.Parse(id));
        }

        public List<User> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
