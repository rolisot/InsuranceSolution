namespace Insurance.Domain.Models
{
    public class BrokerParameter
    {
        protected BrokerParameter(){}

        public BrokerParameter(Broker broker, decimal commission)
        {
            this.Broker = broker;
            this.Commission = commission;
        }

        public int BrokerParameterId { get; private set; }
        public decimal Commission { get; private set; }
        public virtual Broker Broker { get; set; }
    }
}
