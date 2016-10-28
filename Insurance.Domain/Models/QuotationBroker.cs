using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Insurance.Domain.Models
{
    public class QuotationBroker
    {
        protected QuotationBroker(){}

        public QuotationBroker(Quotation quotation, BrokerInsurance brokerInsurance)
        {
            this.Quotation = quotation;
            this.BrokerInsurance = brokerInsurance;
        }

        public int QuotationBrokerId { get; private set; }
        public virtual Quotation Quotation { get; private set; }
        public virtual BrokerInsurance BrokerInsurance { get; private set; }

        [IgnoreDataMember]
        public ICollection<Estimate> Estimates { get; set; }
    }
}
