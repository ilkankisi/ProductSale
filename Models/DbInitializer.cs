using MyApiProject.Data;

namespace MyApiProject.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            // Tablolar zaten doluysa çalıştırma
            if (context.Categories.Any() || context.Brands.Any() || context.Products.Any())
                return;

            // Kategoriler
            var cat1 = new Category { Name = "Elektronik" };
            var cat2 = new Category { Name = "Kitap" };

            // Markalar
            var brand1 = new Brand { Name = "Apple" };
            var brand2 = new Brand { Name = "Samsung" };

            // Etiketler
            var tag1 = new Tag { Name = "yeni" };
            var tag2 = new Tag { Name = "kampanya" };

            // Ürünler
            var product1 = new Product
            {
                Name = "iPhone 15 Pro",
                Price = 54999.99m,
                CreatedDate = DateTime.UtcNow,
                Category = cat1,
                Brand = brand1,
                Tags = new List<Tag> { tag1, tag2 },
                Images = new List<ProductImage>
                {
                    new ProductImage { Url = "https://cdn.example.com/iphone15-front.jpg" },
                    new ProductImage { Url = "https://cdn.example.com/iphone15-back.jpg" }
                }
            };

            var product2 = new Product
            {
                Name = "Galaxy S24 Ultra",
                Price = 48999.99m,
                CreatedDate = DateTime.UtcNow,
                Category = cat1,
                Brand = brand2,
                Tags = new List<Tag> { tag1 },
                Images = new List<ProductImage>
                {
                    new ProductImage { Url = "https://cdn.example.com/galaxy-front.jpg" }
                }
            };

            // Stoklar
            var stock1 = new ProductStock
            {
                Product = product1,
                Quantity = 25,
                Location = "Merkez Depo"
            };

            var stock2 = new ProductStock
            {
                Product = product2,
                Quantity = 30,
                Location = "Ankara Şube"
            };

            context.Categories.AddRange(cat1, cat2);
            context.Brands.AddRange(brand1, brand2);
            context.Tags.AddRange(tag1, tag2);
            context.Products.AddRange(product1, product2);
            context.ProductStocks.AddRange(stock1, stock2);

            context.SaveChanges();
        }
    }
}
