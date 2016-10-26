using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Insurance.Domain.Models
{
    public class Customer
    {
        #region Constructors
        protected Customer()
        {

        }

        public Customer(User user, string name, string cpf, string phone, DateTime birthDate)
        {
            this.User = user;
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
        public DateTime BirthDate { get; private set; }
        public virtual User User { get; set; }
        public virtual CustomerAddress Address { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Quotation> Quotations { get; set; }
        #endregion

        #region Methods

        #endregion
    }
}
