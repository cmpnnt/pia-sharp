using System.Runtime.InteropServices;

namespace Cmpnnt.Pia.Ctl.Lib;

/// <summary>
/// Utilities related to the execution environment of the piactl binary.
/// </summary>
public static class PiaEnvironment
{
    
    /// <summary>
    /// Returns a default path to the piactl binary based on the current operation system
    /// </summary>
    /// <exception cref="ArgumentException">Thrown if running in an operating system other than
    /// Windows, Linux or MacOs</exception>
    public static string PiaPath
    {
        get{

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return @"C:\Program Files\Private Internet Access\piactl.exe";
            }
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return @"/usr/local/bin/piactl";
            }

            throw new ArgumentException("Unknown operating system");
        }
    }
}
