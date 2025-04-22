using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly DatabaseHandler _database;
		private readonly IConfiguration _configuration;

		public AuthController(DatabaseHandler databaseHandler, IConfiguration configuration)
		{
			_database = databaseHandler;
			_configuration = configuration;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest loginRequest)
		{
			var user = GetAuthenticatedUser(loginRequest);
			if (user is null)
				return Unauthorized();

			var token = CreateJwtToken(user);
			return Ok(new { Token = token });
		}

		private Employee? GetAuthenticatedUser(LoginRequest loginRequest)
		{
			var user = _database.Connection.Table<Employee>()
				.FirstOrDefault(e => e.Email == loginRequest.Email);

			if (user is null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
				return null;

			return user;
		}

		private string CreateJwtToken(Employee user)
		{
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim("firstname", user.Firstname),
				new Claim("email", user.Email),
				new Claim("role", user.Role),
				new Claim("organization", user.OrganizationId.ToString()),
			};

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public class LoginRequest
		{
			public required string Email { get; set; }
			public required string Password { get; set; }
		}
	}
}
