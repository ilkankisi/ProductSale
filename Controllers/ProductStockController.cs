namespace MyApiProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyApiProject.Data;
    using MyApiProject.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductStockController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStock>>> Get() =>
            await _context.ProductStocks.Include(s => s.Product).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductStock>> Get(int id)
        {
            var stock = await _context.ProductStocks.Include(s => s.Product).FirstOrDefaultAsync(s => s.Id == id);
            return stock is null ? NotFound() : Ok(stock);
        }

        [HttpPost]
        public async Task<ActionResult<ProductStock>> Post(ProductStock stock)
        {
            // Ürün var mı kontrolü
            var productExists = await _context.Products.AnyAsync(p => p.Id == stock.ProductId);
            if (!productExists)
                return BadRequest("Geçersiz ProductId.");

            _context.ProductStocks.Add(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = stock.Id }, stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductStock updated)
        {
            if (id != updated.Id) return BadRequest();

            var existing = await _context.ProductStocks.FindAsync(id);
            if (existing is null) return NotFound();

            existing.Quantity = updated.Quantity;
            existing.Location = updated.Location;
            existing.ProductId = updated.ProductId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stock = await _context.ProductStocks.FindAsync(id);
            if (stock is null) return NotFound();

            _context.ProductStocks.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
