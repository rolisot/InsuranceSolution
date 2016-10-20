namespace Insurance.Api.Contracts
{
    public class CreateBrokerContract
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public int CityId { get; set; }
    }
}