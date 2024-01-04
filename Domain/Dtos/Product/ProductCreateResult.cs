namespace Domain.Dtos.Product
{
    public class ProductCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}