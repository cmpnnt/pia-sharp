namespace Cmpnnt.Pia.Test;

public class Helpers
{
    public static string CommandLinePath()
    {
        if(OperatingSystem() == Os.Windows)
        {
            return @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
        }
        if(OperatingSystem() == Os.Linux)
        {
            return @"/usr/bin/bash";
        }
        if(OperatingSystem() == Os.MacOs)
        {
            // TODO: Get the MacOS piactl command line executable location
            throw new ArgumentException("MacOS is currently unsupported because of limitations in .NET 7.");
        }

        throw new ArgumentException("Unknown operating system");
    }

    public static Os OperatingSystem()
    {
        string description = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier;

        if(description.ToLower().Contains("win"))
        {
            return Os.Windows;
        }
        if(description.ToLower().Contains("linux"))
        {
            return Os.Linux;
        }
        if(description.ToLower().Contains("osx"))
        {
            return Os.MacOs;
        }

        return Os.Other;
    }
}

public enum Os
{
    Windows,
    Linux,
    MacOs,
    Other,
}
