using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Backend;
using Backend.Models;
using Backend.Controllers;
using Xunit;

namespace SE_Platzverwaltung.Tests
{
    public class AuthControllerTests
    {
        private readonly Mock<DatabaseHandler> _mockDatabaseHandler;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _mockDatabaseHandler = new Mock<DatabaseHandler>();
            _mockConfiguration = new Mock<IConfiguration>();
            _authController = new AuthController(_mockDatabaseHandler.Object, _mockConfiguration.Object);
        }

        [Fact]
        public void Login_ReturnsOkResult_WhenUserIsAuthenticated()
        {
            // Arrange: Mock a valid user in the database
            var loginRequest = new AuthController.LoginRequest
            {
                Email = "test@example.com",
                Password = "validpassword"
            };

            var mockUser = new Employee
            {
                Email = "test@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("validpassword"),
                Firstname = "John",
                Role = "Admin",
                OrganizationId = 1
            };

            // Mock database handler to return the user
            _mockDatabaseHandler.Setup(db => db.Connection.Table<Employee>()
                .FirstOrDefault(It.IsAny<Func<Employee, bool>>()))
                .Returns(mockUser);

            // Mock the IConfiguration for JWT configuration values
            _mockConfiguration.Setup(c => c["Jwt:Key"]).Returns("secretkey");
            _mockConfiguration.Setup(c => c["Jwt:Issuer"]).Returns("issuer");
            _mockConfiguration.Setup(c => c["Jwt:Audience"]).Returns("audience");

            // Act: Call the Login method
            var result = _authController.Login(loginRequest);

            // Assert: Verify that the result is an OkObjectResult with a token
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<System.Dynamic.ExpandoObject>(okResult.Value);
            Assert.NotNull(returnValue);
        }

        [Fact]
        public void Login_ReturnsUnauthorized_WhenUserIsNotAuthenticated()
        {
            // Arrange: Mock an invalid user (wrong password)
            var loginRequest = new AuthController.LoginRequest
            {
                Email = "test@example.com",
                Password = "wrongpassword"
            };

            var mockUser = new Employee
            {
                Email = "test@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("validpassword"),
                Firstname = "John",
                Role = "Admin",
                OrganizationId = 1
            };

            // Mock database handler to return the user
            _mockDatabaseHandler.Setup(db => db.Connection.Table<Employee>()
                .FirstOrDefault(It.IsAny<Func<Employee, bool>>()))
                .Returns(mockUser);

            // Act: Call the Login method with wrong password
            var result = _authController.Login(loginRequest);

            // Assert: Verify that the result is Unauthorized
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
