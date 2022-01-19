# SimpleDateTimeProvider

A simple abstraction over C#'s `DateTime.Now`, `DateTime.Today` and `DateTime.UtcNow` so you can control these values in your tests. No longer do you have to attempt shennanigans in your tests to handle when you need to use those values in your code.

## Features

 * `SystemDateTimeProvider` - Abstraction over the top of System.DateTime. 
 * `MockDateTimeProvider` - Provider used to mock DateTime values in test projects.


## Setup

It's easy to get under way using the providers, simply inject the system provider under the `IDateTimeProvider` interface in your functional code.  If you are using another library you'll know the syntax but follow the same formula.

```csharp
_ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
```

Create your class and use that registered `SystemDateTimeProvider` that we just created via the `IDateTimeProvider` interface.  Then use the provider to set the `DateTime` values in your class.

```csharp
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
}
```

## Testing

The whole purpose of this was to allow for testable code.  So now that you have your class above, you can inject the `MockDateTimeProvider` in its place to control the `DateTime` values in your tests.  It's as easy as the sample below.  

```csharp
[Fact]
public void Today_ShouldReturn_MockedToday()
{
    // Arrange
    var provider = new MockDateTimeProvider();
    var service = new Service(provider);
    var today = DateTime.Today;

    provider.Today = today;

    // Act
    var result = service.DateTimeToday();

    // Assert
    _ = result.ShouldBeOfType<string>();
    result.ShouldBe($"DateTime.Today is {today}");
}
```

## Support

I'm sharing some of my work here and if it helps you, I'd love it if you'd consider supporting me at [Buy Me A Coffee](https://www.buymeacoffee.com/stphnwlsh)
