using System;

namespace Insurance.Domain.Models
{
    public class InsuranceCompany
    {
        protected InsuranceCompany(){}

        public InsuranceCompany(string name)
        {
            this.Name = name;
            this.Active = true;
        }

        public byte InsuranceId { get; private set; }
        public string Name { get; private set; }
        public Boolean Active { get; private set; }
    }
}
