using Cmpnnt.Pia.Ctl.Enums;

namespace Cmpnnt.Pia.Ctl.Extensions;

public static class CommandExtensions
{
    /// <summary>
    /// A more efficient version of ToString() for enums.
    /// </summary>
    /// <param name="command">A Command enum value</param>
    /// <returns>A lowercase version of the name of the enum.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ToStringF(this Command command) =>
        command switch
        {
            Command.Background => nameof(Command.Background),
            Command.Connect => nameof(Command.Connect),
            Command.DedicatedIp => nameof(Command.DedicatedIp),
            Command.Disconnect => nameof(Command.Disconnect),
            Command.Get => nameof(Command.Get),
            Command.Login => nameof(Command.Login),
            Command.Logout => nameof(Command.Logout),
            Command.Monitor => nameof(Command.Monitor),
            Command.ResetSettings => nameof(Command.ResetSettings),
            Command.Set => nameof(Command.Set),
            _ => throw new ArgumentException("Invalid enum value for Command", nameof(command)),
        };
}
