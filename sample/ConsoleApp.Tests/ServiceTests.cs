namespace ConsoleApp.Tests;

using System;
using ConsoleApp;
using Shouldly;
using SimpleDateTimeProvider;
using Xunit;

public class SystemDateTimeProviderTests
{
    [Fact]
    public void Now_ShouldReturn_MockedNow()
    {
        // Arrange
        var provider = new MockDateTimeProvider();
        var service = new Service(provider);
        var now = DateTime.Now;

        provider.Now = now;

        // Act
        var result = service.DateTimeNow();

        // Assert
        _ = result.ShouldBeOfType<string>();
        result.ShouldBe($"DateTime.Now is {now}");
    }

    [Fact]
    public void Now_ShouldReturn_MockedToday()
    {
        // Arrange
        var provider = new MockDateTimeProvider();
        var service = new Service(provider);
        var today = DateTime.Today;

        provider.Today = today;

        // Act
        var result = service.DateTimeToday();

        // Assert
        _ = result.ShouldBeOfType<string>();
        result.ShouldBe($"DateTime.Today is {today}");
    }

    [Fact]
    public void Now_ShouldReturn_MockedUtcNow()
    {
        // Arrange
        var provider = new MockDateTimeProvider();
        var service = new Service(provider);
        var utcNow = DateTime.UtcNow;

        provider.UtcNow = utcNow;

        // Act
        var result = service.DateTimeUtcNow();

        // Assert
        _ = result.ShouldBeOfType<string>();
        result.ShouldBe($"DateTime.UtcNow is {utcNow}");
    }
}
