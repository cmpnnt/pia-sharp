using Cmpnnt.Pia.Ctl.Enums;

namespace Cmpnnt.Pia.Ctl.Extensions;

public static class StatusExtensions
{
    /// <summary>
    /// A more efficient version of ToString() for enums.
    /// </summary>
    /// <param name="status">A Status value</param>
    /// <returns>A lowercase version of the name of the enum.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ToStringF(this Status status) =>
        status switch
        {
            Status.Started => nameof(Status.Started),
            Status.NotStarted => nameof(Status.NotStarted),
            Status.Completed => nameof(Status.Completed),
            Status.Canceled => nameof(Status.Canceled),
            Status.Error => nameof(Status.Error),
            _ => throw new ArgumentException("Invalid enum value for Status", nameof(status)),
        };
}