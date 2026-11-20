using System.ComponentModel.DataAnnotations;

namespace Electronics_and_Accessories_Store.Dtos
{
    public class LoginDto
    {
        [Required] public string Phone { get; set; } = "";
        [Required] public string Password { get; set; } = "";
    }
}