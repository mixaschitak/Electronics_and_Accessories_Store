namespace Electronics_and_Accessories_Store.Dtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = "";
        public UserDto User { get; set; } = new();
    }
}