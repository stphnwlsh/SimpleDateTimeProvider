namespace SimpleDateTimeProvider.Tests.Unit.Extentions
{
    using System;
    using AutoFixture.Xunit2;
    using Shouldly;
    using SimpleDateTimeProvider.Enums;
    using SimpleDateTimeProvider.Exceptions;
    using SimpleDateTimeProvider.Extentions;
    using Xunit;

    public class DateTimeExtensions
    {
        [Theory, AutoData]
        internal void ThrowIfNotSet_ShouldNotThrowException_NotMinValue(DateTimeType type)
        {
            // Arrange
            var dateTime = DateTime.Now;

            // Act
            var result = Should.NotThrow(() => dateTime.ThrowIfNotSet(type));

            // Assert
            result.ShouldBe(dateTime);
        }

        [Theory, AutoData]
        internal void ThrowIfNotSet_ShouldThrowException_IsMinValue(DateTimeType type)
        {
            // Arrange
            var dateTime = DateTime.MinValue;

            // Act
            var exception = Should.Throw<MockDateTimeNotSetException>(() => dateTime.ThrowIfNotSet(type));

            // Assert
            _ = exception.ShouldNotBeNull();
            exception.Message.ShouldBe($"MockDateTimeProvider.{type} was not set for the test execution.");
        }
    }
}
