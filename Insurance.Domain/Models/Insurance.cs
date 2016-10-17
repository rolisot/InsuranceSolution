using System;

namespace Insurance.Domain.Models
{
    public class Insurance
    {
        protected Insurance(){}

        public Insurance(string name)
        {
            this.Name = name;
            this.Active = true;
        }

        public int InsuranceId { get; private set; }
        public string Name { get; private set; }
        public Boolean Active { get; private set; }
    }
}
