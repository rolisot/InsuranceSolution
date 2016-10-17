using System;

namespace Insurance.Domain.Models
{
    public class Broker
    {
        protected Broker() { }
                    
        public Broker(string name, string cnpj)
        {
            this.Name = name;
            this.Cnpj = cnpj;
            this.Active = true;
        }

        public int BrokerId { get; private set; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public Boolean Active { get; private set; }
        public virtual City City { get; set; }
    }
}
