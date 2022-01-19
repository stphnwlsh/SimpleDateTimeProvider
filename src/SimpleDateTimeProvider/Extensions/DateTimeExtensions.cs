namespace SimpleDateTimeProvider.Extensions
{
    using System;
    using Enums;
    using Exceptions;

    internal static class DateTimeExtensions
    {
        /// <summary>
        /// Throws an <see cref="MockDateTimeNotSetException"/> if the value on the  <see cref="DateTime"/> has not been set.
        /// </summary>
        /// <param name="dateTime">
        /// The <see cref="DateTime"/> object being validated.
        /// </param>
        /// <param name="type">
        /// The <see cref="DateTimeType"/> being validated, included in exception message if required.
        /// </param>
        /// <exception cref="MockDateTimeNotSetException">
        /// Thrown if the <paramref name="dateTime"/> has not been set.
        /// </exception>
        /// <returns>
        /// Returns <paramref name="dateTime"/> if it has been set.
        /// </returns>
        internal static DateTime ThrowIfNotSet(this DateTime dateTime, DateTimeType type)
        {
            if (dateTime == DateTime.MinValue)
            {
                throw new MockDateTimeNotSetException($"MockDateTimeProvider.{type} was not set for the test execution.");
            }

            return dateTime;
        }
    }
}
