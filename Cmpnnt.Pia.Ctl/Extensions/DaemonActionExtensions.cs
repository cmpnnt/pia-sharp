using Cmpnnt.Pia.Ctl.Enums;

namespace Cmpnnt.Pia.Ctl.Extensions;

public static class DaemonActionExtensions
{
    /// <summary>
    /// A more efficient version of ToString() for enums.
    /// </summary>
    /// <param name="action">A DaemonAction value</param>
    /// <returns>A lowercase version of the name of the enum.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ToStringF(this DaemonAction action) =>
        action switch
        {
            DaemonAction.AllowLan => nameof(DaemonAction.AllowLan),
            DaemonAction.ConnectionState => nameof(DaemonAction.ConnectionState),
            DaemonAction.DebugLogging => nameof(DaemonAction.DebugLogging),
            DaemonAction.PortForward => nameof(DaemonAction.PortForward),
            DaemonAction.Protocol => nameof(DaemonAction.Protocol),
            DaemonAction.PubIp => nameof(DaemonAction.PubIp),
            DaemonAction.Region => nameof(DaemonAction.Region),
            DaemonAction.Regions => nameof(DaemonAction.Regions),
            DaemonAction.RequestPortForward => nameof(DaemonAction.RequestPortForward),
            DaemonAction.VpnIp => nameof(DaemonAction.VpnIp),
            _ => throw new ArgumentException("Invalid enum value for DaemonAction", nameof(action)),
        };
}