namespace SimpleDateTimeProvider.Exceptions
{
    using System;
    using System.Text.Json.Serialization;

    /// <summary>
    /// A custom <see cref="Exception"/> to handle the incorrectly setup MockDateTimeProviders.
    /// </summary>
    public class MockDateTimeNotSetException : Exception
    {
        /// <summary>
        /// Throws an <see cref="MockDateTimeNotSetException"/> with the <paramref name="message"/>.
        /// </summary>
        /// <param name="message">
        /// The message to be set on the exception.
        /// </param>
        [JsonConstructor]
        public MockDateTimeNotSetException(string message)
            : base(message)
        {
        }
    }
}
