# SimpleDateTimeProvider

[![Build Pipeline](https://github.com/stphnwlsh/SimpleDateTimeProvider/actions/workflows/build-pipeline.yml/badge.svg)](https://github.com/stphnwlsh/SimpleDateTimeProvider/actions/workflows/build-pipeline.yml)
[![NuGet](https://img.shields.io/nuget/v/SimpleDateTimeProvider.svg)](https://www.nuget.org/packages/SimpleDateTimeProvider)
[![NuGet downloads](https://img.shields.io/nuget/dt/SimpleDateTimeProvider.svg)](https://www.nuget.org/packages/SimpleDateTimeProvider)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)

A tiny abstraction over `DateTime.Now`, `DateTime.Today` and `DateTime.UtcNow`, so your tests decide what time it is instead of the clock on the build server.

No more tests that only fail at midnight, on the 29th of February, or in a time zone nobody on the team lives in.

## Install

```sh
dotnet add package SimpleDateTimeProvider
```

It has no dependencies, so that's the whole shopping list.

## Use it

Register the real clock against the interface:

```csharp
_ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
```

Then ask for `IDateTimeProvider` wherever you'd have reached for `DateTime`:

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

    public string DateTimeToday()
    {
        return $"DateTime.Today is {this.dateTimeProvider.Today}";
    }
}
```

`SystemDateTimeProvider` hands straight through to `DateTime`, so in production nothing changes.

## Test it

In your tests, swap in `MockDateTimeProvider` and set whichever values the test needs:

```csharp
[Fact]
public void Today_ShouldReturn_MockedToday()
{
    // Arrange
    var provider = new MockDateTimeProvider();
    var service = new Service(provider);
    var today = new DateTime(2024, 2, 29);

    provider.Today = today;

    // Act
    var result = service.DateTimeToday();

    // Assert
    result.ShouldBe($"DateTime.Today is {today}");
}
```

Forget to set one and you get a `MockDateTimeNotSetException` telling you which, rather than a quiet `01/01/0001` that sends you on a long walk through the debugger.

The [sample](sample) folder has a console app and its tests with all three values.

## What about `TimeProvider`?

Fair question. .NET 8 brought [`TimeProvider`](https://learn.microsoft.com/dotnet/api/system.timeprovider), with `FakeTimeProvider` in [Microsoft.Extensions.TimeProvider.Testing](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing) for tests, and [Microsoft.Bcl.TimeProvider](https://www.nuget.org/packages/Microsoft.Bcl.TimeProvider) takes it back to older frameworks. It also does timers and time zones. If you're starting fresh on modern .NET, it's a fine choice, and I've written about [bending DateTime in .NET 8](https://medium.com/gitconnected/bending-datetime-in-net-8-to-test-your-code-better-52e5cd83be4c) with it.

SimpleDateTimeProvider is for when you'd rather have three properties you can just set, or your code already uses it and has better things to do than migrate. They're friends, not rivals.

## Supported frameworks

The package ships a .NET Standard 2.0 build and a .NET 10 build. .NET Standard 2.0 covers:

- .NET Framework 4.6.1 and later (4.7.2 and later is happier)
- .NET Core 2.0 and later, and every .NET since
- Mono, Xamarin and Unity

Every change is tested on .NET 10, and on .NET Framework 4.8 on Windows, so the old frameworks aren't just a promise on a badge.

## Releases

It looks after itself. Dependabot opens one pull request on the 15th of each month, and on the 1st anything merged that changes the package goes to NuGet with a [GitHub release](https://github.com/stphnwlsh/SimpleDateTimeProvider/releases) to match. Versions are dates, so `2026.12.1.42` came out on 1 December 2026.

## Contributing

Bug reports, ideas and pull requests are all welcome. [CONTRIBUTING.md](CONTRIBUTING.md) has how to build and test it, and the [code of conduct](CODE_OF_CONDUCT.md) has how to be excellent to each other. Security problems go through the [security policy](SECURITY.md), not an issue.

## Thanks

A few people showed me why mocking `DateTime` is worth the trouble. Thanks to [Andrew Harcourt](https://github.com/uglybugger) for pushing it at unnamed previous employers, and to Andrew Wickens and Jared Wilton, my team at Tigerspike, for keeping me honest and always learning.

If it saves you some time, you can [sponsor the work](https://github.com/sponsors/stphnwlsh). It also funds [Lean Mean Clean Apps](https://leanmeancleanapps.github.io), and the coffee.

## Licence

[MIT](LICENSE.md), so do what you like with it.
