namespace SimpleDateTimeProvider
{
    using System;
    using SimpleDateTimeProvider.Enums;
    using SimpleDateTimeProvider.Extentions;

    /// <summary>
    /// Defines a DateTime implementation that returns the mocked values for use in testing.
    /// </summary>
    public class MockDateTimeProvider : IDateTimeProvider
    {
        private DateTime now;
        private DateTime today;
        private DateTime utcNow;

        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        /// <exception cref="MockDateTimeNotSetException">
        /// Thrown if the <paramref name="now"/> has not been set.
        /// </exception>
        /// <returns>
        /// A <see cref="DateTime">System.DateTime</see> that has been previously set to return.
        /// </returns>
        public DateTime Now
        {
            get => this.now.ThrowIfNotSet(DateTimeType.Now);
            set => this.now = value;
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <exception cref="MockDateTimeNotSetException">
        /// Thrown if the <paramref name="now"/> has not been set.
        /// </exception>
        /// <returns>
        /// A <see cref="DateTime">System.DateTime</see> that has been previously set to return.
        /// </returns>
        public DateTime Today
        {
            get => this.today.ThrowIfNotSet(DateTimeType.Today);
            set => this.today = value;
        }

        /// <summary>
        /// Gets a <see cref="DateTime">System.DateTime</see> object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        /// <exception cref="MockDateTimeNotSetException">
        /// Thrown if the <paramref name="now"/> has not been set.
        /// </exception>
        /// <returns>
        /// A <see cref="DateTime">System.DateTime</see> that has been previously set to return.
        /// </returns>
        public DateTime UtcNow
        {
            get => this.utcNow.ThrowIfNotSet(DateTimeType.UtcNow);
            set => this.utcNow = value;
        }
    }
}
