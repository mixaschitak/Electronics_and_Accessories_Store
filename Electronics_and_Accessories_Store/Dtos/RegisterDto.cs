using System.ComponentModel.DataAnnotations;

namespace Electronics_and_Accessories_Store.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Телефон обязателен")]
        public string Phone { get; set; } = "";

        [Required]
        [MinLength(4, ErrorMessage = "Пароль не короче 4 символов")]
        public string Password { get; set; } = "";
    }
}