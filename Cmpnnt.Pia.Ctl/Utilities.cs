using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl;

public class Utilities(PiaCtl piaCtl)
{
    private readonly PiaCtl _piaCtl = piaCtl;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="regionPrefix"></param>
    /// <returns></returns>
    public async Task<PiaResults> SwitchToFastest(MultiRegion regionPrefix)
    {
        PiaResults regions = await piaCtl.GetRegions();
        
        if (regions.Status != Status.Completed)
        {
            // return the original results if the request didn't complete
            return regions;
        }

        foreach(string r in regions.StandardOutputResults)
        {
            PiaResults results = new();
            
            var currentRegion = r.Trim().Substring(0, 2);
            
            if (!currentRegion.Equals(regionPrefix.ToStringF(), StringComparison.CurrentCultureIgnoreCase)) continue;
            
            string newRegion = r.Trim();
            results.Status = Status.Completed;
            results.StandardOutputResults = [newRegion];
            await piaCtl.SetRegion(newRegion);

            return results;
        }

        var errorMessage = "Unable to switch to a new region.";
        return new PiaResults{Status = Status.Error, StandardOutputResults = [errorMessage] };

    }
}