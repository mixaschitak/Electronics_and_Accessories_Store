using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Electronics_and_Accessories_Store.Data;
using Electronics_and_Accessories_Store.Models;
using Electronics_and_Accessories_Store.Dtos;
using Electronics_and_Accessories_Store.Services;

namespace Electronics_and_Accessories_Store.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(AppDbContext db, JwtService jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var phoneTaken = await _db.Users
                .AnyAsync(u => u.Phone == dto.Phone);
            if (phoneTaken)
                return Conflict("Этот телефон уже зарегистрирован");

            var user = new User
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Role = Roles.User
            };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(new AuthResponseDto
            {
                Token = _jwt.CreateToken(user),
                User = ToDto(user)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Phone == dto.Phone);

            if (user == null ||
                _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password)
                == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Неверный телефон или пароль");
            }

            return Ok(new AuthResponseDto
            {
                Token = _jwt.CreateToken(user),
                User = ToDto(user)
            });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var idText = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idText, out var id))
                return Unauthorized();

            var user = await _db.Users.FindAsync(id);
            if (user == null)
                return Unauthorized();

            return Ok(ToDto(user));
        }

        private static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id, Name = user.Name,
                Phone = user.Phone, Role = user.Role
            };
        }
    }
}