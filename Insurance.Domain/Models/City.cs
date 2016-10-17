using System;

namespace Insurance.Domain.Models
{
    public class City
    {
        protected City() { }

        public int CityId { get; private set; }
        public string Name { get; private set; }
        public Boolean Capital { get; private set; }
        public virtual State State { get; private set; }
    }
}