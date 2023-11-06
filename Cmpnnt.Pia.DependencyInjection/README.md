# Cmpnnt.Pia.DependencyInjection

This is a dependency injection helper package for [cmpnnt.pia.ctl](https://nuget.org/packages/cmpnnt.pia.ctl).

`Cmpnnt.Pia.Ctl` is a .NET wrapper around `piactl`, the Private Internet Access CLI for Windows and Linux (MacOS support is coming with .NET 8).

PIA Sharp's main package, Cmpnnt.Pia.Ctl, has been tested against version 3.3.1 on Windows and Linux. It provides access to every
piactl command available in those version on those systems. It might also work on other versions of piactl, provided they expose
the same commands with the same parameters. However, this hasn't been tested and nothing is guaranteed.

## Dependency Injection

There's a separate dependency injection library you can use if you require DI. Add a reference to
[Cmpnnt.Pia.DependencyInjection](https://nuget.org/packages/cmpnnt.pia.dependencyinjection) and include it in your DI container by adding
a call to `services.AddPiaCtl()` under `ConfigureServices`.

> Note: The dependency injection package registers `PiaCtl` as a singleton.

Here's a basic example. You can find the runnable code in the [examples project](https://github.com/cmpnnt/pia-sharp/tree/main/Cmpnnt.Pia.Examples).

```csharp
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddPiaCtl();
        services.AddScoped<SomeClass>();
    })
    .ConfigureLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
    })
    .Build();
```

### Configuration

You can also pass a lambda function to `AddPiaCtl` to configure the path to your system's `piactl` application, if it differs
from the default. On Windows, the default location is `C:\Program Files\Private Internet Access\piactl.exe`.

```csharp
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddPiaCtl(options =>
        {
            options.PiaPath = @"C:\path\to\piactl.exe";
        });
        services.AddScoped<SomeClass>();
    })
    .ConfigureLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
    })
    .Build();
```