namespace Insurance.Domain.Contracts
{
    public class CustomerContract
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public CustomerAddressContract Address { get; set; }
        public string BirthDate { get; set; }
    }
}
