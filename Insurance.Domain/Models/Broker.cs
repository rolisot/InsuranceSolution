using System;
using System.Collections.Generic;

namespace Insurance.Domain.Models
{
    public class Broker
    {
        protected Broker() { }
                    
        public Broker(string name, string cnpj)
        {
            this.Name = name;
            this.Cnpj = cnpj;
            this.Active = true;
        }

        public int BrokerId { get; private set; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public Boolean Active { get; private set; }
        public virtual BrokerAddress Address { get; set; }

        public ICollection<BrokerInsurance> BrokerInsurance { get; set; }
        public ICollection<BrokerPlan> BrokerPlan { get; set; }
        public ICollection<BrokerParameter> BrokerParameter { get; set; }
        public ICollection<CalculateIntegration> CalculateIntegration { get; set; }

    }
}
