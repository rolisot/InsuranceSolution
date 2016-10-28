using Insurance.Domain.Enumerators;
using System;

namespace Insurance.Domain.Models
{
    public class CalculateIntegration
    {
        protected CalculateIntegration(){}

        public CalculateIntegration(Quotation quotation, Broker broker, string sendText)
        {
            this.Quotation = quotation;
            this.Broker = broker;
            this.SendText = sendText;
            this.Status = CalculatingIntegrationStatusType.New;
        }

        public int CalculateIntegrationId { get; private set; }
        public virtual Quotation Quotation { get; set; }
        public virtual Broker Broker { get; set; }
        public DateTime? SendDate { get; private set; }
        public DateTime? ReceiveDate { get; private set; }
        public string SendText { get; private set; }
        public string ReceiveText { get; private set; }
        public CalculatingIntegrationStatusType Status { get; private set; }


        public void SetToSended()
        {
            this.SendDate = DateTime.Now;
            this.Status = CalculatingIntegrationStatusType.Sended;
        }

        public void SetToReceived(string receivedText)
        {
            this.ReceiveText = receivedText;
            this.ReceiveDate = DateTime.Now;
            this.Status = CalculatingIntegrationStatusType.Received;
        }

        public void SetToOnEstimate()
        {
            this.Status = CalculatingIntegrationStatusType.OnEstimate;
        }

        public void SetToFinished()
        {
            this.Status = CalculatingIntegrationStatusType.Finished;
        }
    }
}
