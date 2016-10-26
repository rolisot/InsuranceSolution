namespace Insurance.Domain.Contracts
{
    public class CustomerAddressContract
    {
        public string Address { get; set; }
        public string Cep { get; set; }
        public string Neighborhood { get; set; }
        public int CityId { get; set; }
    }
}
