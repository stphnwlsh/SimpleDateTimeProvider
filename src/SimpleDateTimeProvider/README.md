# SimpleDateTimeProvider

A tiny abstraction over `DateTime.Now`, `DateTime.Today` and `DateTime.UtcNow`, so your tests decide what time it is instead of the clock on the build server. No dependencies, and it runs anywhere .NET Standard 2.0 does, from .NET Framework 4.6.1 to .NET 10.

## Use it

Register the real clock against the interface, then ask for `IDateTimeProvider` wherever you'd have reached for `DateTime`:

```csharp
_ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
```

```csharp
public class Service
{
    private readonly IDateTimeProvider dateTimeProvider;

    public Service(IDateTimeProvider dateTimeProvider)
    {
        this.dateTimeProvider = dateTimeProvider;
    }

    public string DateTimeToday()
    {
        return $"DateTime.Today is {this.dateTimeProvider.Today}";
    }
}
```

## Test it

Swap in `MockDateTimeProvider` and set whichever values the test needs:

```csharp
var provider = new MockDateTimeProvider { Today = new DateTime(2024, 2, 29) };
var service = new Service(provider);

service.DateTimeToday().ShouldBe($"DateTime.Today is {new DateTime(2024, 2, 29)}");
```

Forget to set one and you get a `MockDateTimeNotSetException` telling you which, rather than a quiet `01/01/0001`.

## More

The [README on GitHub](https://github.com/stphnwlsh/SimpleDateTimeProvider) has the rest, including how it compares with .NET 8's `TimeProvider`. If it saves you some time, you can [sponsor the work](https://github.com/sponsors/stphnwlsh).
