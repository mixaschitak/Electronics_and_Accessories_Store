using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Electronics_and_Accessories_Store.Data;
using Electronics_and_Accessories_Store.Models;
using Electronics_and_Accessories_Store.Dtos;

namespace Electronics_and_Accessories_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonesControllers : ControllerBase
    {
        private readonly AppDbContext _db;

        public PhonesControllers(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, int? colorId)
        {
            var query = _db.Products
                .Include(p => p.Color)
                .AsQueryable();

            if (colorId != null)
                query = query.Where(p => p.ColorId == colorId);

            var products = await query.ToListAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var text = search.Trim();
                products = products
                    .Where(p => p.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _db.Products
                .Include(p => p.Color)
                .Include(p => p.ReleaseDate)
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Create(SavePhoneDto dto)
        {
            var newProduct = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                ColorId = dto.ColorId,
                ImageUrl = dto.ImageUrl,
                ReleaseDateId = dto.ReleaseDateId,
                ManufacturerId = dto.ManufacturerId
            };

            _db.Products.Add(newProduct);
            await _db.SaveChangesAsync();

            return Created($"/api/PhonesControllers/{newProduct.Id}", newProduct);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Update(int id, SavePhoneDto dto)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.ColorId = dto.ColorId;
            product.ReleaseDateId = dto.ReleaseDateId;
            product.ManufacturerId = dto.ManufacturerId;

            await _db.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}