namespace SimpleDateTimeProvider.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    /// <summary>
    /// A custom <see cref="Exception"/> to handle the incorrectly setup MockDateTimeProviders.
    /// </summary>
    [Serializable]
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

        /// <summary>
        /// Serializable <see cref="MockDateTimeNotSetException"/>.
        /// </summary>
        /// <param name="info">
        /// Serialization info
        /// </param>
        /// <param name="context">
        /// Streaming context
        /// </param>
        protected MockDateTimeNotSetException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
