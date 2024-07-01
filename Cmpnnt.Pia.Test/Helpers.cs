﻿using System.Runtime.InteropServices;

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
            return @"/bin/zsh";
        }

        throw new ArgumentException("Unknown operating system");
    }

    public static Os OperatingSystem()
    {
        string description = RuntimeInformation.RuntimeIdentifier;

        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return Os.Windows;
        }
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return Os.Linux;
        }
        if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
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
