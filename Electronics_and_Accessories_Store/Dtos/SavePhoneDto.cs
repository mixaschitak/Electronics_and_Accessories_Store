using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_and_Accessories_Store.Dtos
{
    public class SavePhoneDto
    {
        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(40, ErrorMessage = "Не длиннее 40 символов")]
        public string Name { get; set; } = "";

        [Range(1, 100000, ErrorMessage = "Цена от 1 до 100000")]
        public int Price { get; set; }
        [Range(1, int.MaxValue,ErrorMessage = "Укажите номер категории")]
        public int ColorId { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}