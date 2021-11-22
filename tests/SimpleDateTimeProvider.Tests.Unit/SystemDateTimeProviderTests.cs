namespace SimpleDateTimeProvider.Tests.Unit
{
    using System;
    using Shouldly;
    using Xunit;

    public class SystemDateTimeProviderTests
    {
        [Fact]
        public void Now_ShouldReturn_SystemNow()
        {
            // Arrange
            var provider = new SystemDateTimeProvider();
            var systemNow = DateTime.Now;

            // Act
            var result = provider.Now;


            // Assert
            _ = result.ShouldBeOfType<DateTime>();
            result.Year.ShouldBe(systemNow.Year);
            result.Month.ShouldBe(systemNow.Month);
            result.Day.ShouldBe(systemNow.Day);
            result.Hour.ShouldBe(systemNow.Hour);
            result.Minute.ShouldBe(systemNow.Minute);
            result.Second.ShouldBeInRange(systemNow.Second, systemNow.Second + 1);
        }


        [Fact]
        public void Today_ShouldReturn_SystemToday()
        {
            // Arrange
            var provider = new SystemDateTimeProvider();
            var systemToday = DateTime.Today;

            // Act
            var result = provider.Today;


            // Assert
            _ = result.ShouldBeOfType<DateTime>();
            result.Year.ShouldBe(systemToday.Year);
            result.Month.ShouldBe(systemToday.Month);
            result.Day.ShouldBe(systemToday.Day);
            result.Hour.ShouldBe(systemToday.Hour);
            result.Minute.ShouldBe(systemToday.Minute);
            result.Second.ShouldBeInRange(systemToday.Second, systemToday.Second + 1);
        }


        [Fact]
        public void UtcNow_ShouldReturn_SystemUtcNow()
        {
            // Arrange
            var provider = new SystemDateTimeProvider();
            var systemUtcNow = DateTime.UtcNow;

            // Act
            var result = provider.UtcNow;


            // Assert
            _ = result.ShouldBeOfType<DateTime>();
            result.Year.ShouldBe(systemUtcNow.Year);
            result.Month.ShouldBe(systemUtcNow.Month);
            result.Day.ShouldBe(systemUtcNow.Day);
            result.Hour.ShouldBe(systemUtcNow.Hour);
            result.Minute.ShouldBe(systemUtcNow.Minute);
            result.Second.ShouldBeInRange(systemUtcNow.Second, systemUtcNow.Second + 1);
        }
    }
}
