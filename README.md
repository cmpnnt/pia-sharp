# PIA Sharp

![NuGet Version](https://img.shields.io/nuget/v/Cmpnnt.Pia.Ctl?style=flat-square)
![Static Badge](https://img.shields.io/badge/line%20coverage-90.40%25-ded11b?style=flat-square)
![Static Badge](https://img.shields.io/badge/branch%20coverage-74.10%25-ded11b?style=flat-square)
![GitHub last commit](https://img.shields.io/github/last-commit/cmpnnt/pia-sharp?style=flat-square)
![Static Badge](https://img.shields.io/badge/License-MIT-37ad13?style=flat-square)

`Cmpnnt.Pia.Ctl` is a .NET Native AOT wrapper around the `piactl` command line tool for the
[Private Internet Access](https://privateinternetaccess.com) VPN. It's available on [Nuget](https://nuget.org/profiles/cmpnnt).

## Installation

The Nuget packages comes in "plain" and dependency-injected versions. The plain version is a meta-package contains binaries for Windows x64, Linux x64, MacOS x64, and MacOS arm64.

`dotnet add package cmpnnt.pia.ctl`

To include the dependency injected version in your project, run the following command. This version references the
meta-package of the plain version, so you do not need to install it explicitly.

`dotnet add package cmpnnt.pia.dependencyinjection`

## Developer Documentation

See the [API reference](https://cmpnnt.github.io/pia-sharp/) for more detailed documentation.