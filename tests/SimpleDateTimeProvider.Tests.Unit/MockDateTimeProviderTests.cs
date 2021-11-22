namespace SimpleDateTimeProvider.Tests.Unit
{
    using System;
    using AutoFixture.Xunit2;
    using Shouldly;
    using SimpleDateTimeProvider.Exceptions;
    using Xunit;

    public class MockDateTimeProviderTests
    {
        [Fact]
        public void Now_ShouldThrowException_MockDateTimeNotSetException()
        {
            // Arrange
            var provider = new MockDateTimeProvider();

            // Act
            var exception = Should.Throw<MockDateTimeNotSetException>(() => _ = provider.Now);

            // Assert
            _ = exception.ShouldBeOfType<MockDateTimeNotSetException>();
            exception.Message.ShouldBe("MockDateTimeProvider.Now was not set for the test execution.");
        }

        [Theory, AutoData]
        public void Now_ShouldReturn_SetDateTime(DateTime dateTime)
        {
            // Arrange
            var provider = new MockDateTimeProvider
            {
                Now = dateTime
            };

            // Act
            var result = provider.Now;


            // Assert
            _ = result.ShouldBeOfType<DateTime>();
            result.ShouldBe(dateTime);
        }

        [Fact]
        public void Today_ShouldThrowException_MockDateTimeNotSetException()
        {
            // Arrange
            var provider = new MockDateTimeProvider();

            // Act
            var exception = Should.Throw<MockDateTimeNotSetException>(() => _ = provider.Today);

            // Assert
            _ = exception.ShouldBeOfType<MockDateTimeNotSetException>();
            exception.Message.ShouldBe("MockDateTimeProvider.Today was not set for the test execution.");
        }

        [Theory, AutoData]
        public void Today_ShouldReturn_SetDateTime(DateTime dateTime)
        {
            // Arrange
            var provider = new MockDateTimeProvider
            {
                Today = dateTime
            };

            // Act
            var result = provider.Today;


            // Assert
            _ = result.ShouldBeOfType<DateTime>();
            result.ShouldBe(dateTime);
        }

        [Fact]
        public void UtcNow_ShouldThrowException_MockDateTimeNotSetException()
        {
            // Arrange
            var provider = new MockDateTimeProvider();

            // Act
            var exception = Should.Throw<MockDateTimeNotSetException>(() => _ = provider.UtcNow);

            // Assert
            _ = exception.ShouldBeOfType<MockDateTimeNotSetException>();
            exception.Message.ShouldBe("MockDateTimeProvider.UtcNow was not set for the test execution.");
        }

        [Theory, AutoData]
        public void UtcNow_ShouldReturn_SetDateTime(DateTime dateTime)
        {
            // Arrange
            var provider = new MockDateTimeProvider
            {
                UtcNow = dateTime
            };

            // Act
            var result = provider.UtcNow;


            // Assert
            _ = result.ShouldBeOfType<DateTime>();
            result.ShouldBe(dateTime);
        }
    }
}
