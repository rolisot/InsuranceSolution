using Insurance.Common.Helper;
using System;
using System.Runtime.Serialization;

namespace Insurance.Domain.Models
{
    public class BrokerAddress
    {
        protected BrokerAddress(){}

        public BrokerAddress(Broker broker, string address, string cep, string neighborhood, City city)
        {
            this.BrokerId = broker.BrokerId;
            this.Broker = broker;
            this.Address = address;
            this.Cep = cep;
            this.Neighborhood = neighborhood;
            this.City = city;
        }

        public int BrokerId { get; set; }
        public string Address { get; set; }
        public string Cep { get; set; }
        public string Neighborhood { get; set; }
        public Decimal Latitude { get; private set; }
        public Decimal Longitude { get; private set; }
        public virtual City City { get; set; }

        [IgnoreDataMember]
        public virtual Broker Broker { get; set; }

        public string GetAddressToGoogleMaps()
        {
            return string.Concat(this.Address, " ", this.City.Name, " ", this.City.State.Abbreviation, " Brasil");
        }

        public void SetAddressCoordinates(Geolocation geolocation)
        {
            if (geolocation != null)
            {
                this.Latitude = geolocation.Latitude;
                this.Longitude = geolocation.Longitude;
            }
        }
    }
}
