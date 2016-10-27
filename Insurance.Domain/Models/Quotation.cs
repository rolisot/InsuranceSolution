using Insurance.Domain.Enumerators;
using System;
using System.Collections.Generic;

namespace Insurance.Domain.Models
{
    public class Quotation
    {
        protected Quotation(){}

        public Quotation(Customer customer, City city)
        {
            this.RegisterDate = DateTime.Now;
            this.Customer = customer;
            this.City = city;
            this.SetNewStatus();
        }

        public int QuotationId { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public QuotationStatusType Status { get; private set; }
        public virtual Customer Customer { get; set; }
        public virtual City City { get; set; }

        public ICollection<QuotationBroker> QuotationBroker { get; set; }

        public ICollection<CalculateIntegration> CalculateIntegration { get; set; }

        public void SetNewStatus()
        {
            this.Status = QuotationStatusType.New;
        }

        public void SetProcessingStatus()
        {
            this.Status = QuotationStatusType.Processing;
        }

        public void SetWaitCalculateStatus()
        {
            this.Status = QuotationStatusType.WaitCalculate;
        }

        public void SetProcessingCalculateStatus()
        {
            this.Status = QuotationStatusType.ProcessingCalculate;
        }

        public void SetEstimateInAnalisysStatus()
        {
            this.Status = QuotationStatusType.EstimateInAnalisys;
        }
    }
}
