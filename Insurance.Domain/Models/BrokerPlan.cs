using System;

namespace Insurance.Domain.Models
{
    public class BrokerPlan
    {
        protected BrokerPlan(){}

        public BrokerPlan(Broker broker, Plan plan)
        {
            this.Broker = broker;
            this.Plan = plan;
            this.SetDates();
        }

        public int BrokerPlanId { get; private set; }
        public virtual Broker Broker { get; set; }
        public virtual Plan Plan { get; set; }
        public DateTime BuyDate { get; private set; }
        public DateTime ExpireDate { get; private set; }

        private void SetDates() {
            this.BuyDate = DateTime.Now;
            this.ExpireDate = this.BuyDate.AddDays(this.Plan.Days);
        }
    }
}
