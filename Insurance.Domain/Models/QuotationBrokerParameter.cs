namespace Insurance.Domain.Models
{
    public class QuotationBrokerParameter
    {
        protected QuotationBrokerParameter(){}

        public QuotationBrokerParameter(Quotation quotation, Broker broker, decimal comission)
        {
            this.Quotation = quotation;
            this.Broker = broker;
            this.Comission = comission;
        }

        public int QuotationBrokerParameterId { get; private set; }
        public virtual Quotation Quotation { get; set; }
        public virtual Broker Broker { get; set; }
        public decimal Comission { get; private set; }
    }
}
