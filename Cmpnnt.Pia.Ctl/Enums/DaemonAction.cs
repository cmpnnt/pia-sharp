namespace Cmpnnt.Pia.Ctl.Enums;

/// <summary>
/// Represents "sub-commands" available as getters, setters and monitoring commands.
/// Note that not all DaemonActions are available for every Command.
/// </summary>
public enum DaemonAction
{
    None = 0,
    AllowLan,
    ConnectionState,
    DebugLogging,
    PortForward,
    Protocol,
    PubIp,
    Region,
    Regions,
    RequestPortForward,
    VpnIp
}
