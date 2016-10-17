using System;

namespace Insurance.Domain.Models
{
    public class EstimateRevision
    {
        protected EstimateRevision(){}

        public EstimateRevision(Estimate estimate)
        {
            this.Estimate = estimate;
            this.StartRevision = DateTime.Now;
        }

        public int EstimateRevisionId { get; private set; }
        public DateTime StartRevision { get; private set; }
        public DateTime? EndRevision { get; private set; }
        public virtual Estimate Estimate { get; private set; }


        public void SetEndRevision()
        {
            this.EndRevision = DateTime.Now;
        }
    }
}
