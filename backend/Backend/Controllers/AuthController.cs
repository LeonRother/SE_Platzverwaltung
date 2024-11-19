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
		private readonly DatabaseHandler _db;
		private readonly IConfiguration _config;
		public AuthController(DatabaseHandler databaseHandler, IConfiguration configuration)
		{
			_db = databaseHandler;
			_config = configuration;
		}

		[HttpPost("/login")]
		public IActionResult Login([FromBody] LoginBody login)
		{
			var user = AuthenticateUser(login);
			if (user == null)
				return Unauthorized();

			var token = GenerateJwtToken(user);
			return Ok(new { Token = token });
		}

		private Employee? AuthenticateUser(LoginBody login)
		{
			var employee = _db.Connection.Table<Employee>().Where(e => e.Email == login.Email).FirstOrDefault();
			if (employee == null) return null;

			if (BCrypt.Net.BCrypt.Verify(login.Password, employee.Password))
				return employee;
			else
				return null;
		}

		private string GenerateJwtToken(Employee employee)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
				new Claim("email", employee.Email),
				new Claim("role", employee.Role),
				new Claim("organization", employee.OrganizationId.ToString()),
			};
			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(1),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public class LoginBody
		{
			public required string Email { get; set; }
			public required string Password { get; set; }
		}
	}
}
