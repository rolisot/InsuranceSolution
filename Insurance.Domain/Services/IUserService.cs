﻿using Insurance.Domain.Models;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Services
{
    public interface IUserService : IDisposable
    {
        User GetByEmail(string email);
        User GetById(string id);
        List<User> GetByRange(int skip, int take);
        List<User> GetAll();
        void Create(string email, string password, string confirmPassword);
        void ChangeInformation(string email, string name);
        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);
        string ResetPassword(string email);
    }
}
