using Insurance.Domain.Enumerators;

namespace Insurance.Domain.Models
{
    public class Estimate
    {
        protected Estimate(){}

        public Estimate(decimal price, QuotationBroker quotationBroker)
        {
            this.Price = price;
            this.QuotationBroker = quotationBroker;
            this.Status = EstimateStatusType.New;
        }

        public int EstimateId { get; private set; }
        public decimal Price { get; private set; }
        public EstimateStatusType Status { get; private set; }
        public virtual QuotationBroker QuotationBroker { get; set; }
    }
}
