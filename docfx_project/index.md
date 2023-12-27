# PIA Sharp

`Cmpnnt.Pia.Ctl` is a .NET Native AOT wrapper around the `piactl` command line tool for the
[Private Internet Access](https://privateinternetaccess.com) VPN. It's available on [Nuget](https://nuget.org/profiles/cmpnnt) and supports Windows and Linux.

> MacOS is currently unsupported because there are no free MacOS GitHub action runners available that support .NET 8.
> There are older (Intel) MacOS runners available for free, but they only support up to .NET 7.
> This repository will be updated to build MacOS packages if and when this changes.

## Compatibility

PIA Sharp's main package, `Cmpnnt.Pia.Ctl`, has been tested against version `3.3.1` on Windows and Linux. 
It provides access to every `piactl` command available in those version on those systems. It might also work on other 
versions of `piactl`, provided they expose the same commands with the same parameters. However, this hasn't 
been tested and nothing is guaranteed.

## Setup

You must have a Private Internet Access account and the `piactl` command line application installed on your system.
This is included with their desktop GUI application.

There are two ways to use `Cmpnnt.Pia.Ctl`: [Dependency Injection](#dependency-injection) and simple [instantiation](#instantiation)

### Dependency Injection

There's a separate dependency injection library you can use if you require DI. Add a reference to
[Cmpnnt.Pia.DependencyInjection](https://nuget.org/packages/cmpnnt.pia.dependencyinjection) and include it in your DI container by adding
a call to `services.AddPiaCtl()` under `ConfigureServices`.

> [!NOTE]
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

#### Configuration

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

### Instantiation

If you don't need DI, you can use the command-line wrapper by itself by including a reference to `Cmpnnt.Pia.Ctl`, available as a
[nuget package](https://nuget.org/packages/cmpnnt.pia.ctl).

```csharp
PiaCtl pia = new PiaCtl();
PiaResults results = await pia.GetRegions();
Console.WriteLine(results);
```

## Usage

Full API documentation is available in the [API Reference](api/index.md).

### Commands

> TODO: Add link to developer documentation

`Cmpnnt.Pia.Ctl` allows access to every command exposed by `piactl`. The methods are all asynchronous, but don't include the `async` suffix.
The available commands are as follows. See [the API reference](http://todo) for detailed developer documentation.

### Results (command line output)

All `PiaCtl` commands return a `Task<PiaResults>`, which contains a `Status` enum indicating the result of the operation and a `List<string>`
for each of stdout and stderr output. The `ToString()` method has been overridden to return a JSON-formatted string with that information
(using source generation for the JSON serialization).

## Compiling

Because `Cmpnnt.Pia.Ctl` is a .NET 8 Native AOT library, it requires additional tooling to compile. 

### Windows

On _Windows_, install
[Visual Studio 2022](http://visualstudio.com) with the Desktop Development for C++ workload. 

### Linux

On _Linux_, install the following packages, depending on your distribution:

Ubuntu 18.04+
```shell
sudo apt-get install clang zlib1g-dev
```

Alpine 3.15+
```shell
sudo apk add clang build-base zlib-dev
```

### MacOS

To compile on MacOS, you'll need to install the latest [Command Line Tools for XCode](https://developer.apple.com/download/).

## References

Links to various articles and documentation referenced while building this project can be found [here](articles/references.md)