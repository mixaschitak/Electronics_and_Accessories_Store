using Microsoft.AspNetCore.Mvc;
namespace ElectronicsTest.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class PhonesControllers : ControllerBase

    {
        private static readonly List<Phone> Products = new()
            {
                new Phone{ Id = 1, Name = "Айфон", Price = 1000},
                new Phone{ Id = 2, Name = "Самсунг", Price = 800},
                new Phone{ Id = 3, Name = "Реалми", Price = 600},

            };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Products);
    }

        [HttpGet("{id}")]        
    public IActionResult GetById(int id){
    var Phone = Products.FirstOrDefault(p => p.Id == id);
        if (Phone == null) return NotFound();
        return Ok(Phone.Name);
            
        }
        [HttpPost]
        public IActionResult Create(Phone phone)
        
        {
            if (string.IsNullOrWhiteSpace(phone.Name) && phone.Price <= 0)
            {
                return BadRequest("Нужны названия и цена больше 0");  
            }
            phone.Id = Products.Max(p => p.Id) + 1;
            Products.Add(phone);
           return Created($"/api/Product/{phone.Id}",phone);
        }
    }

}