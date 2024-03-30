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
            
            string description = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier;

            if(description.ToLower().Contains("win"))
            {
                return @"C:\Program Files\Private Internet Access\piactl.exe";
            }
            if(description.ToLower().Contains("linux"))
            {
                return @"/usr/local/bin/piactl";
            }
            if(description.ToLower().Contains("osx"))
            {
                throw new ArgumentException("MacOS is currently unsupported.");
            }

            Console.WriteLine($"The operating system is {description}.");
            throw new ArgumentException("Unknown operating system");
        }
    }
}
