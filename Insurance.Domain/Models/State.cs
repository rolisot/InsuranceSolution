using System.Collections.Generic;

namespace Insurance.Domain.Models
{
    public class State
    {
        protected State() { }

        public byte StateId { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<City> Cities { get; set; }
    }
}