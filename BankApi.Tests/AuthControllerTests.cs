using BankApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using System.Collections.Generic;

public class AuthControllerTests
{
    [Fact]
    public void Login_ReturnsToken_WhenCredentialsAreValid()
    {
        // Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"Jwt:Key", "gTTZsH0t8BCqRer9GKJn/0lxJ/Ox94EXAf8i/3UcMmg="},
            {"Jwt:Issuer", "testissuer"},
            {"Jwt:Audience", "testaudience"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var authController = new AuthController(configuration);
        var loginModel = new AuthController.LoginModel
        {
            Username = "test",
            Password = "password"
        };

        // Act
        var result = authController.Login(loginModel) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public void Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
    {
        // Arrange
        var inMemorySettings = new Dictionary<string, string> {
            {"Jwt:Key", "testkey"},
            {"Jwt:Issuer", "testissuer"},
            {"Jwt:Audience", "testaudience"}
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var authController = new AuthController(configuration);
        var loginModel = new AuthController.LoginModel
        {
            Username = "wronguser",
            Password = "wrongpassword"
        };

        // Act
        var result = authController.Login(loginModel);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}
