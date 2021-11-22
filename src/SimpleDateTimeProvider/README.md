# SimpleDateTimeProvider

A simple abstraction over C#'s DateTime.Now, DateTime.Today and DateTime.UtcNow so you can control these values in your tests.

## Features

 * `SystemDateTimeProvider` - Abstraction over the top of System.DateTime. 
 * `MockDateTimeProvider` - Mockable provider to control DateTime values in test projects.


## Getting Started
It's easy to get under way using the providers

```csharp
_ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
```
