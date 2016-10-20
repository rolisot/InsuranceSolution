namespace Insurance.Api.Contracts
{
    public class CreatePlanContract
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }
    }
}