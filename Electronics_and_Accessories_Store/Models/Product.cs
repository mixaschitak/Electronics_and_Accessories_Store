using System.Drawing;
namespace Electronics_and_Accessories_Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Price { get; set; }

        public int ColorId { get; set; }
        
        public Color? Color { get; set; }
        public string ImageUrl { get; set; } = "";
    }
}