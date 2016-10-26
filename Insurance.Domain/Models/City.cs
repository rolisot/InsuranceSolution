using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Insurance.Domain.Models
{
    public class City
    {
        protected City() { }

        public int CityId { get; private set; }
        public string Name { get; private set; }
        public Boolean Capital { get; private set; }
        public virtual State State { get; private set; }

        [IgnoreDataMember]
        public virtual ICollection<BrokerAddress> BrokerAddress { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}