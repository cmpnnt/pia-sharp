using Cmpnnt.Pia.Ctl.Enums;

namespace Cmpnnt.Pia.Ctl.Lib.Results;

public interface ICliResults
{
    List<string> StandardOutputResults { get; set; }
    List<string> StandardErrorResults { get; set; }
    Status Status { get; set; }
}