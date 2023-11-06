# PIA Sharp README

`Cmpnnt.Pia.Ctl` is a .NET 7 Native AOT wrapper around the `piactl` command line tool for the
[Private Internet Access](https://privateinternetaccess.com) VPN. It's available on [Nuget](https://nuget.org/profiles/cmpnnt)
(currently version 0.1.0).

> MacOS is currently unsupported because the .NET 7 SDK only supports Native AOT for Windows and Linux. MacOS support is
> coming in .NET 8, at which point this library will be updated.

## Installation

The Nuget packages comes in "plain" and dependency-injected versions. The plain version is a meta-package that conditionally
references the appropriate version for your OS and architecture. I recommend using this package instead of directly referencing
the system-specific packages. To include it in your project, run:

`dotnet add package cmpnnt.pia.ctl`

To include the dependency injected version in your project, run the following command. This version references the
meta-package of the plain version, so you do not need to install it explicitly.

`dotnet add package cmpnnt.pia.dependencyinjection`

## Developer Documentation

> TODO: Add link to developer documentation
See the [API reference]((http://todo)) for more detailed documentation.