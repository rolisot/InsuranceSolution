namespace Insurance.Domain.Contracts
{
    public class PlanContract
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }
    }
}
