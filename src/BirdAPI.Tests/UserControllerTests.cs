using BirdAPI.ApiService.Controllers;
using BirdAPI.ApiService.Database.Models;
using BirdAPI.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BirdAPI.Tests.Tests;

public class UserControllerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _controller = new UserController(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateFakeUsers_ReturnsOkWithUserIds()
    {
        // Arrange
        var fakeUserCount = 5;
        var fakeUserIds = Enumerable.Range(1, fakeUserCount).Select(i => Guid.NewGuid()).ToList();
        _userRepositoryMock.Setup(repo => repo.AddFakeUsersAsync(fakeUserCount, It.IsAny<CancellationToken>()))
                           .ReturnsAsync(fakeUserIds);

        // Act
        var result = await _controller.CreateFakeUsers(fakeUserCount);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUserIds = Assert.IsAssignableFrom<IEnumerable<Guid>>(okResult.Value);
        Assert.Equal(fakeUserIds.Count, returnedUserIds.Count());
    }
}