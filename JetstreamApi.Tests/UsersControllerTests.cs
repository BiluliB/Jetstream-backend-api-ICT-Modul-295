using JetstreamApi.Controllers;
using JetstreamApi.DTO;
using JetstreamApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JetstreamApi.Tests
{
    /// <summary>
    /// Controller login tests for the users controller without token validation
    /// </summary>
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<ITokenService> _mockTokenService;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockTokenService = new Mock<ITokenService>();
            _controller = new UsersController(_mockUserService.Object, _mockTokenService.Object);
        }

        [Fact]
        public async Task Login_Success_ReturnsOkWithToken()
        {
            // Arrange
            var userLoginDto = new UserLoginDTO { UserName = "user", Password = "password" };
            _mockUserService.Setup(s => s.VerifyPassword(userLoginDto.UserName, userLoginDto.Password)).Returns(true);
            _mockTokenService.Setup(s => s.CreateToken(userLoginDto.UserName)).Returns("test_token");

            // Act
            var result = await _controller.Login(userLoginDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task Login_Exception_ReturnsBadRequest()
        {
            // Arrange
            var userLoginDto = new UserLoginDTO { UserName = "user", Password = "password" };
            _mockUserService.Setup(s => s.VerifyPassword(userLoginDto.UserName, userLoginDto.Password)).Throws(new System.Exception("Error"));

            // Act
            var result = await _controller.Login(userLoginDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error", badRequestResult.Value);
        }
    }

}
