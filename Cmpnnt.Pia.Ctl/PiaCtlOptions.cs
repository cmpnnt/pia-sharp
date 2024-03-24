using Cmpnnt.Pia.Ctl.Lib;

namespace Cmpnnt.Pia.Ctl;

/// <summary>
/// Allows configuration of <see cref="PiaCtl"/>
/// </summary>
public class PiaCtlOptions
{
    public string PiaPath { get; set; } = PiaEnvironment.PiaPath;
}
