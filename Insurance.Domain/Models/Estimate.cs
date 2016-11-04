using Insurance.Domain.Enumerators;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Insurance.Domain.Models
{
    public class Estimate
    {
        private int quotationBrokerSetterId;

        public Estimate()
        {
            this.QuotationBroker = new QuotationBroker();
        }

        public Estimate(decimal price, QuotationBroker quotationBroker)
        {
            this.Price = price;
            this.QuotationBroker = quotationBroker;
            this.Status = EstimateStatusType.New;
        }

        public int EstimateId { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("status")]
        public EstimateStatusType Status { get; set; }

        [XmlAttribute("quotationbrokerid")]
        [IgnoreDataMember]
        public int QuotationBrokerSetterId
        {
            get { return this.quotationBrokerSetterId; }
            set {
                this.quotationBrokerSetterId = value;
                this.QuotationBroker.QuotationBrokerId = this.quotationBrokerSetterId;
            }
        }

        public virtual QuotationBroker QuotationBroker { get; set; }

    }
}
