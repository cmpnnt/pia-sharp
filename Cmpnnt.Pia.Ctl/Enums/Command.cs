namespace Cmpnnt.Pia.Ctl.Enums;

/// <summary>
/// Represents "top-level" piactl commands such as getters, setters, monitoring and connection commands.
/// </summary>
public enum Command
{
    None = 0,
    Background,
    Connect,
    DedicatedIp,
    Disconnect,
    Get,
    Login,
    Logout,
    Monitor,
    ResetSettings,
    Set
}