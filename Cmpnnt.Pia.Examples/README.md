# README

This is a runnable example application to illustrate how to use the `Cmpnnt.Pia.DependencyInjection` package.
You must have a Private Internet Access account and the `piactl` command line application installed on your system. 
This is included with their desktop GUI application.

To start it, run `dotnet run` in the command line from the example project directory. It should log a JSON-formatted string
to the console showing your PIA daemon's current VPN protocol (either openvpn or wireguard). Use `ctrl+c` to exit.

Sample output: 

```
Cmpnnt.Pia.Examples.SomeClass[0]
{
"StandardOutputResults": [
  "openvpn"
],
"StandardErrorResults": null,
"Status": "Completed"
}
```