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

    [HttpGet("{id}")]        public IActionResult GetById(int id){
    var Phone = Products.FirstOrDefault(p => p.Id == id);
        if (Phone == null) return NotFound();
        return Ok(Phone.Name);
            
        }

    }

}