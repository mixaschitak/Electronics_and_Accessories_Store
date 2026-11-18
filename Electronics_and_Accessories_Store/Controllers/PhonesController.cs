using Microsoft.AspNetCore.Mvc;
using Electronics_and_Accessories_Store.Dtos;
using Electronics_and_Accessories_Store.Models; 

namespace Electronics_and_Accessories_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonesControllers : ControllerBase
    {
        private static readonly List<Phone> Products = new()
        {
            new Phone { Id = 1, Name = "Айфон", Price = 1000 },
            new Phone { Id = 2, Name = "Самсунг", Price = 800 },
            new Phone { Id = 3, Name = "Реалми", Price = 600 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var phone = Products.FirstOrDefault(p => p.Id == id);
            if (phone == null)
                return NotFound();

            return Ok(phone);
        }

        [HttpPost]
        public IActionResult Create(SavePhoneDto dto)
        {
            var newPhone = new Phone
            {
                Name = dto.Name,
                Price = dto.Price
            };

            newPhone.Id = Products.Any()
                ? Products.Max(p => p.Id) + 1
                : 1;

            Products.Add(newPhone);

            return Created($"/api/PhonesControllers/{newPhone.Id}", newPhone);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SavePhoneDto dto)
        {
            var phone = Products.FirstOrDefault(p => p.Id == id);
            if (phone == null) return NotFound();

            phone.Name = dto.Name;
            phone.Price = dto.Price;
            return Ok(phone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var phone = Products.FirstOrDefault(p => p.Id == id);
            if (phone == null)
                return NotFound();

            Products.Remove(phone);
            return NoContent();
        }
    }
}