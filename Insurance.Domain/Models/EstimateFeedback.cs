using System;

namespace Insurance.Domain.Models
{
    public class EstimateFeedback
    {
        protected EstimateFeedback(){}

        public EstimateFeedback(Estimate estimate, FeedbackReason feedbackReason)
        {
            this.Estimate = estimate;
            this.FeedbackReason = feedbackReason;
            this.RegisterDate = DateTime.Now;
        }

        public int EstimateFeedbackId { get; private set; }
        public virtual Estimate Estimate { get; set; }
        public virtual FeedbackReason FeedbackReason { get; set; }
        public DateTime RegisterDate { get; private set; }
    }
}
