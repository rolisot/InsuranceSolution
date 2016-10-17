namespace Insurance.Domain.Models
{
    public class BrokerParameter
    {
        protected BrokerParameter(){}

        public BrokerParameter(Broker broker, decimal comission)
        {
            this.Broker = broker;
            this.Comission = comission;
        }

        public int BrokerParameterId { get; private set; }
        public decimal Comission { get; private set; }
        public virtual Broker Broker { get; set; }
    }
}
