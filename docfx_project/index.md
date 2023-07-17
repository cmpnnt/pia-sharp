# Developer Documentation

For basic installation instructions, see the [main readme](https://github.com/cmpnnt/pia-sharp#readme).

## Compatibility

`Cmpnnt.Pia.Ctl` has been tested against version `3.3.1` on Windows and Linux (MacOS is unsupported until .NET 8). 
It provides access to every `piactl` command available in those version on those systems. It might also work on other 
versions of `piactl`, provided they expose the same commands with the same parameters. However, this hasn't 
been tested and nothing is guaranteed.

## Setup

You must have a Private Internet Access account and the `piactl` command line application installed on your system.
This is included with their desktop GUI application.

There are two ways to use `Cmpnnt.Pia.Ctl`: [Dependency Injection](#dependency-injection) and simple [instantiation](#instantiation)

### Dependency Injection

There's a separate dependency injection library you can use if you require DI. Add a reference to
[Cmpnnt.Pia.DependencyInjection](https://nuget.org/XXX) and include it in your DI container by adding
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
[nuget package](https://nuget.org/XXX).

```csharp
PiaCtl pia = new PiaCtl();
PiaResults results = await pia.GetRegions();
Console.WriteLine(results);
```

## Usage

Full API documentation is available in the [API Reference](api/index.md).

### Commands

`Cmpnnt.Pia.Ctl` allows access to every command exposed by `piactl`. The methods are all asynchronous, but don't include the `async` suffix.
The available commands are as follows. See [the API reference](http://google.com) for detailed developer documentation.

### Results (command line output)

All `PiaCtl` commands return a `Task<PiaResults>`, which contains a `Status` enum indicating the result of the operation and a `List<string>`
for each of stdout and stderr output. The `ToString()` method has been overridden to return a JSON-formatted string with that information
(using source generation for the JSON serialization).

## Compiling

Because `Cmpnnt.Pia.Ctl` is a .NET 7 Native AOT library, it requires additional tooling to compile. 

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

`Cmpnnt.Pia.Ctl` currently does not support MacOS because Dotnet 7 does not yet support it for Native AOT. Dotnet 8 will
include MacOS, at which time this library will be updated and Nuget packages will be released. When that happens, you'll
need to install the latest [Command Line Tools for XCode](https://developer.apple.com/download/) to compile this project.

## References

Links to various articles and documentation referenced while building this project can be found [here](articles/references.md)