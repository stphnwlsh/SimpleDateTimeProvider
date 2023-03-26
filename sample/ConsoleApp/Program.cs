using System;
using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using SimpleDateTimeProvider;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IDateTimeProvider, SystemDateTimeProvider>()
    .AddSingleton<Service>()
    .BuildServiceProvider();

var service = serviceProvider.GetService<Service>();

Console.WriteLine(service.DateTimeNow());
Console.WriteLine(service.DateTimeToday());
Console.WriteLine(service.DateTimeUtcNow());
