namespace SimpleDateTimeProvider
{
    using System;

    /// <summary>
    /// Defines a DateTime implementation that returns the system values.
    /// </summary>
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime">System.DateTime</see> whose value is the current local date and time.
        /// </returns>
        public DateTime Now => DateTime.Now;

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime">System.DateTime</see> that is set to today's date, with the time component set to 00:00:00.
        /// </returns>
        public DateTime Today => DateTime.Today;

        /// <summary>
        /// Gets a <see cref="DateTime">System.DateTime</see> object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime">System.DateTime</see> whose value is the current UTC date and time.
        /// </returns>
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
