﻿namespace Insurance.Api.Contracts
{
    public class CreateUserContract
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }
    }
}