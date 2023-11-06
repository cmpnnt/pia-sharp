# Cmpnnt.Pia.Ctl

`Cmpnnt.Pia.Ctl` is a .NET wrapper around `piactl`, the Private Internet Access CLI for Windows and Linux (MacOS support is coming with .NET 8).

PIA Sharp's main package, Cmpnnt.Pia.Ctl, has been tested against version 3.3.1 on Windows and Linux. It provides access to every 
piactl command available in those version on those systems. It might also work on other versions of piactl, provided they expose 
the same commands with the same parameters. However, this hasn't been tested and nothing is guaranteed.

This package can be used by simply instantiating `PiaCtl` as follows:

```csharp
PiaCtl pia = new PiaCtl();
PiaResults results = await pia.GetRegions();
Console.WriteLine(results);
```

A dependency injection package is also [available](https://nuget.org/packages/cmpnnt.pia.dependencyinjection).