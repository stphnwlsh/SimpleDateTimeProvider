namespace ConsoleApp
{
    using SimpleDateTimeProvider;

    public class Service
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public Service(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public string DateTimeNow()
        {
            return $"DateTime.Now is {this.dateTimeProvider.Now}";
        }

        public string DateTimeToday()
        {
            return $"DateTime.Today is {this.dateTimeProvider.Today}";
        }

        public string DateTimeUtcNow()
        {
            return $"DateTime.UtcNow is {this.dateTimeProvider.UtcNow}";
        }
    }
}
