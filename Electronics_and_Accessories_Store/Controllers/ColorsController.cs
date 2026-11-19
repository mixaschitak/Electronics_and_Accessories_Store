using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Electronics_and_Accessories_Store.Data;

namespace Electronics_and_Accessories_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ColorsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colors = await _db.Colors
                .OrderBy(c => c.Name)
                .ToListAsync();

            return Ok(colors);
        }
    }
}