
using LogiTrack.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogiTrack.Identity.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            if (dto.Email == "manager@test.com" && dto.Password == "1234")
            {
                var token = GenerateToken("1", dto.Email, "Manager");
                return Ok(new { access_token = token });
            }

            if (dto.Email == "driver@test.com" && dto.Password == "1234")
            {
                var token = GenerateToken("2", dto.Email, "Driver");
                return Ok(new { access_token = token });
            }

            return Unauthorized("Invalid credentials");
        }

        private string GenerateToken(string userId, string email, string role)
        {
            // Step 1: Claims
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, userId),
        new Claim(JwtRegisteredClaimNames.Email, email),
        new Claim(ClaimTypes.Role, role)
    };

            // Step 2: Secret Key
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            // Step 3: Signing Credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Step 4: Create Token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            // Step 5: Return Token String
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
