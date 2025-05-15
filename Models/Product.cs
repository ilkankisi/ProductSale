namespace MyApiProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public List<ProductImage> Images { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }
}
