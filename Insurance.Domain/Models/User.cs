using System;

namespace Insurance.Domain.Models
{
    public class User
    {
        #region Constructor
        protected User() { }
        public User(string name, string email)
        {
            this.UserId = Guid.NewGuid();
            this.Email = email;
            this.Active = true;
            this.RegisterDate = DateTime.Now;
            this.LastAccessDate = DateTime.Now;
        }
        #endregion

        #region Properties
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Boolean Active { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public DateTime LastAccessDate { get; private set; }
        #endregion

        #region Methods
        //public void SetPassword(string password, string confirmPassword)
        //{
        //    AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidUserPassword);
        //    AssertionConcern.AssertArgumentNotNull(confirmPassword, Errors.InvalidUserPassword);
        //    AssertionConcern.AssertArgumentLength(password, 6, 20, Errors.InvalidUserPassword);
        //    AssertionConcern.AssertArgumentEquals(password, confirmPassword, Errors.PasswordDoesNotMatch);

        //    this.Password = PasswordAssertionConcern.Encrypt(password);
        //}

        //public string ResetPassword()
        //{
        //    string password = Guid.NewGuid().ToString().Substring(0, 8);
        //    this.Password = PasswordAssertionConcern.Encrypt(password);

        //    return password;
        //}

        //public void ChangeName(string name)
        //{
        //    this.Name = name;
        //}
        //public void Validate()
        //{
        //    AssertionConcern.AssertArgumentLength(this.Name, 3, 250, Errors.InvalidUserName);
        //    EmailAssertionConcern.AssertIsValid(this.Email);
        //    PasswordAssertionConcern.AssertIsValid(this.Password);
        //}

        #endregion
    }
}
