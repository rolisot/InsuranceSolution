using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Insurance.Domain.Models
{
    [System.Xml.Serialization.XmlType("quotationbroker", IncludeInSchema = true)]
    public class QuotationBroker
    {
        public QuotationBroker(){}

        public QuotationBroker(Quotation quotation, BrokerInsurance brokerInsurance)
        {
            this.Quotation = quotation;
            this.BrokerInsurance = brokerInsurance;
        }

        public int QuotationBrokerId { get; set; }
        [XmlIgnore]
        public virtual Quotation Quotation { get; private set; }
        [XmlIgnore]
        public virtual BrokerInsurance BrokerInsurance { get; private set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public ICollection<Estimate> Estimates { get; set; }
    }
}
