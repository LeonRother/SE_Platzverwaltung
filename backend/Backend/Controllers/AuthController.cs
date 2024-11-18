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
				return Unauthorized(); // how do you reject "the right way"?

			var token = GenerateJwtToken(user);
			return Ok(new { Token = token });
		}

		private Employee AuthenticateUser(LoginBody login)
		{
			// hash password with bcrypt
			return _db.Connection.Table<Employee>().Where(e => e.Email == login.Email && e.Password == login.Password).First();
		}

		private string GenerateJwtToken(Employee employee)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
				new Claim(ClaimTypes.Email, employee.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim("Organization", employee.OrganizationId.ToString()),
				new Claim(ClaimTypes.Role, employee.Role)
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
