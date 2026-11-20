namespace Electronics_and_Accessories_Store.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = Roles.User;
    }
}