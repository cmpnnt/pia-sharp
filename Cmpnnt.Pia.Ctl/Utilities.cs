using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Ctl;

public class Utilities
{
    private readonly PiaCtl _piaCtl;

    public Utilities(PiaCtl piaCtl)
    {
        _piaCtl = piaCtl;
    }
    
    public Utilities()
    {
        _piaCtl = new PiaCtl();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="regionPrefix"></param>
    /// <returns></returns>
    public async Task<PiaResults> SwitchToFastest(MultiRegion regionPrefix)
    {
        PiaResults regions = await _piaCtl.GetRegions();
        
        if (regions.Status != Status.Completed)
        {
            // return the original results if the request didn't complete
            return regions;
        }

        // iterate through the list of regions until we find the first one that matches our country
        // the list of regions is already sorted by latency, so the first is the fastest
        foreach(string r in regions.StandardOutputResults)
        {
            PiaResults results = new();
            
            var currentRegion = r.Trim().Split("-")[0];
            
            if (!currentRegion.Equals(regionPrefix.ToStringF(), StringComparison.CurrentCultureIgnoreCase)) continue;
            
            string newRegion = r.Trim();
            results.Status = Status.Completed;
            results.StandardOutputResults = [newRegion];
            await _piaCtl.SetRegion(newRegion);

            return results;
        }

        var errorMessage = "Unable to switch to a new region.";
        return new PiaResults{Status = Status.Error, StandardErrorResults = [errorMessage] };

    }
}