# SimpleDateTimeProvider

A simple abstraction over C#'s DateTime.Now, DateTime.Today and DateTime.UtcNow so you can control these values in your tests. No longer do you have to attempt shennanigans in your tests to handle when you need to use those values in your code.

## Inspiration

I have been lucky enough to work with a few individuals over time who have enlightened me to the utility of being able to mock `DateTime` in my tests.  So thanks to [Andrew Harcourt](https://github.com/uglybugger) for pushing this at unnamed previous employers, and thanks to my team at Andrew Wickens and Jared Wilton at [Tigerspike](https://tigerspike.com) you are responsible for keeping me honest and pushing me to always be learning.

## Features

 * `SystemDateTimeProvider` - Abstraction over the top of System.DateTime. 
 * `MockDateTimeProvider` - Mockable provider to control DateTime values in test projects.


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
public void Now_ShouldReturn_MockedToday()
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

I'm sharing some of my work here and if it helps you, I'd love it if you'd consider supporting me.

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/guidelines/download-assets-sm-1.svg)](https://www.buymeacoffee.com/stphnwlsh)

