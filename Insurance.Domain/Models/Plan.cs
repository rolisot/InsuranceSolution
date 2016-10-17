using System;

namespace Insurance.Domain.Models
{
    public class Plan
    {
        protected Plan() {}

        public Plan(string description, decimal price, int days)
        {
            this.Description = description;
            this.Price = price;
            this.Days = days;
            this.Active = true;
        }

        public int PlanId { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Days { get; private set; }
        public Boolean Active { get; private set; }
    }
}
