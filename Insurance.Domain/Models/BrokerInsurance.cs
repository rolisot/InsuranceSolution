using Insurance.Common.Validation;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Models
{
    public class BrokerInsurance
    {
        protected BrokerInsurance(){}

        public BrokerInsurance(Broker broker, InsuranceCompany insurance, string login, string password)
        {
            this.Broker = broker;
            this.Insurance = insurance;
            this.Login = login;
            this.Password = PasswordValidation.Encrypt(password);
            this.Active = true;
        }

        public int BrokerInsuranceId { get; private set; }
        public Boolean Active { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public virtual Broker Broker { get; set; }
        public virtual InsuranceCompany Insurance { get; set; }

        public ICollection<QuotationBroker> QuotationBroker { get; set; }
    }
}
