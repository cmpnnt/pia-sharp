using Cmpnnt.Pia.Ctl.Enums;

namespace Cmpnnt.Pia.Ctl.Extensions;


public static class MultiRegionExtensions
{
    /// <summary>
    /// A more efficient version of ToString() for enums.
    /// </summary>
    /// <param name="multiRegion">A MultiRegion value</param>
    /// <returns>A lowercase version of the name of the enum.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ToStringF(this MultiRegion multiRegion) =>
        multiRegion switch
        {
            MultiRegion.AU => nameof(multiRegion.AU),
            MultiRegion.CA => nameof(multiRegion.CA),
            MultiRegion.DE => nameof(multiRegion.DE),
            MultiRegion.DK => nameof(multiRegion.DK),
            MultiRegion.ES => nameof(multiRegion.ES),
            MultiRegion.FI => nameof(multiRegion.FI),
            MultiRegion.IT => nameof(multiRegion.IT),
            MultiRegion.JP => nameof(multiRegion.JP),
            MultiRegion.NL => nameof(multiRegion.NL),
            MultiRegion.SE => nameof(multiRegion.SE),
            MultiRegion.UK => nameof(multiRegion.UK),
            MultiRegion.US => nameof(multiRegion.US),
            _ => throw new ArgumentException("Invalid enum value for Status", nameof(multiRegion)),
        };
}