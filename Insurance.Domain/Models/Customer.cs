using System;

namespace Insurance.Domain.Models
{
    public class Customer
    {
        #region Constructors
        protected Customer()
        {

        }

        public Customer(Guid userId, string name, string cpf, string phone, int cityId, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Phone = phone;
            this.BirthDate = birthDate;
        }

        #endregion

        #region Properties
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Phone { get; private set; }
        public virtual User User { get; set; }
        public virtual City City { get; set; }
        public DateTime BirthDate { get; private set; }
        #endregion

        #region Methods

        #endregion
    }
}
