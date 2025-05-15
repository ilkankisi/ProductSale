using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;
using MyApiProject.Models;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductImageController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductImage>>> Get() =>
            await _context.ProductImages.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<ProductImage>> Post(ProductImage image)
        {
            _context.ProductImages.Add(image);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = image.Id }, image);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _context.ProductImages.FindAsync(id);
            if (image is null) return NotFound();

            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
