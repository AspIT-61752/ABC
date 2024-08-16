using ABC.DataAccess;
using ABC.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace ABC.Testing
{
    public class UserAPITest : IClassFixture<WebApplicationFactory<ABC.API.Controllers.UserController>>
    {
        private readonly HttpClient _client;
        private readonly Mock<IUserRepository> _mockRepo;

        public UserAPITest(WebApplicationFactory<ABC.API.Controllers.UserController> factory)
        {
            _mockRepo = new Mock<IUserRepository>();

            var webAppFactory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Remove existing repo registration
                    services.RemoveAll<IUserRepository>();

                    // Register the mock repository
                    services.AddSingleton(_mockRepo.Object);
                });
            });

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task IsUserValid_ReturnsTrue_WhenUserIsValid()
        {
            // Arrange
            var user = new User { Email = "tobsi@gmail.com", Password = "123" };
            _mockRepo.Setup(repo => repo.IsUserValid(user)).Returns(true);

            // Act
            var response = await _client.PostAsync($"/api/User/IsUserValid?Email={user.Email}&Password={user.Password}", null);

            // Assert
            response.EnsureSuccessStatusCode();
            var res = bool.Parse(await response.Content.ReadAsStringAsync()); // Why am I not getting the bool? 
            res.Should().BeTrue();
        }

        [Fact]
        public async Task IsUserValid_ReturnsFalse_WhenUserIsInvalid()
        {
            // Arrange
            var user = new User { Email = "Tobsi@gmail.com", Password = "wrongPass" };
            _mockRepo.Setup(repo => repo.IsUserValid(user)).Returns(false);

            // Act
            var response = await _client.PostAsync($"/api/User/IsUserValid?Email={user.Email}&Password={user.Password}", null);

            // Assert
            response.EnsureSuccessStatusCode();
            var res = bool.Parse(await response.Content.ReadAsStringAsync());
            res.Should().BeFalse();
        }
    }
}
