using System.Collections.Generic;

namespace Insurance.Domain.Contracts
{
    public class BrokerContract
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public BrokerAddressContract Address { get; set; }
        public List<BrokerInsuranceContract> Insurances { get; set; }
        public BrokerParameterContract Parameters { get; set; }
    }
}
