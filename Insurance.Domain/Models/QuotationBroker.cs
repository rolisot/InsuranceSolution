using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Insurance.Domain.Models
{
    public class QuotationBroker
    {
        public QuotationBroker(){}

        public QuotationBroker(Quotation quotation, BrokerInsurance brokerInsurance)
        {
            this.Quotation = quotation;
            this.BrokerInsurance = brokerInsurance;
        }

        public int QuotationBrokerId { get; private set; }
        public virtual Quotation Quotation { get; private set; }
        public virtual BrokerInsurance BrokerInsurance { get; private set; }

        [NotMapped]
        public virtual int BrokerId { get { return this.BrokerInsurance.Broker.BrokerId; } }

        [NotMapped]
        public virtual byte InsuranceId { get { return this.BrokerInsurance.Insurance.InsuranceId; } }

        [XmlIgnore]
        public ICollection<Estimate> Estimates { get; set; }
    }
}
