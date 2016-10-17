namespace Insurance.Domain.Models
{
    public class FeedbackReason
    {
        protected FeedbackReason(){}

        public FeedbackReason(string description)
        {
            this.Description = description;
        }

        public int FeedbackReasonId { get; private set; }
        public string Description { get; private set; }
    }
}