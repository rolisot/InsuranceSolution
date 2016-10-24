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
            this.Status = QuotationStatusType.New;
            this.Customer = customer;
            this.City = city;
        }

        public int QuotationId { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public QuotationStatusType Status { get; private set; }
        public virtual Customer Customer { get; set; }
        public virtual City City { get; set; }

        public ICollection<QuotationBroker> QuotationBroker { get; set; }

    }
}
