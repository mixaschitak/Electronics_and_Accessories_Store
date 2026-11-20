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

        public int ReleaseDateId { get; set; }
        public ReleaseDate? ReleaseDate { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}