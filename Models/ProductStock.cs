namespace MyApiProject.Models
{
    public class ProductStock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
