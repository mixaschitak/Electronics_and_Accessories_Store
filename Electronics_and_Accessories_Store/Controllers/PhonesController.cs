// Product заменить на Pizza

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAll()
        {
            var Pizzas = await _db.Products
            
            .Include(p => p.Color)
            .ToListAsync();
            return Ok(Pizzas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _db.Products
            
            .Include(p => p.ColorId)
            .FirstOrDefaultAsync(p => p.Id ==id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePhoneDto dto)
        {
        var colorExist = await _db.Colors.AnyAsync(c => c.Id == dto.ColorId);
        if (!colorExist) return BadRequest("Цвет не найден");

        var newProduct = new Product
        {
        Name = dto.Name,
        Price = dto.Price,
        ColorId = dto.ColorId,
        ImageUrl = dto.ImageUrl,
        };

    _db.Products.Add(newProduct);
    await _db.SaveChangesAsync();

    return Created($"/api/PhonesControllers/{newProduct.Id}", newProduct);
}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SavePhoneDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _db. Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.ColorId = dto.ColorId;

            await _db.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db. Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _db. Products.Remove(product);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}