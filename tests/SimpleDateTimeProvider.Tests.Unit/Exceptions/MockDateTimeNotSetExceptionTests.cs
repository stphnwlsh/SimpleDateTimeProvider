namespace SimpleDateTimeProvider.Tests.Unit.Exceptions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.Json;
    using Shouldly;
    using SimpleDateTimeProvider.Exceptions;
    using Xunit;

    public class MockDateTimeNotSetExceptionTests
    {
        [Fact]
        public void MockDateTimeNotSetException_ShouldSerializeException_Json()
        {
            // Arrange
            using var stream = new MemoryStream();

            // Act
            Should.NotThrow(async () => await JsonSerializer.SerializeAsync(stream, new MockDateTimeNotSetException("test")));
            stream.Position = 0;
            var exception = Should.NotThrow(async () => await JsonSerializer.DeserializeAsync<MockDateTimeNotSetException>(stream));

            // Assert
            _ = exception.ShouldNotBeNull();
            exception.Message.ShouldBe("test");
        }
    }
}
