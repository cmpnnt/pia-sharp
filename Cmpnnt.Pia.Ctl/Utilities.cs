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
    /// Switches to the fastest server in a given region. The region must have multiple servers.
    /// </summary>
    /// <param name="regionPrefix">The two-letter prefix of the region in which the servers reside.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
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

    /// <summary>
    /// Disconnects the VPN connection for the specified duration. If the advanced killswitch feature
    /// is enabled, snoozing the VPN will prevent internet access.
    /// </summary>
    /// <param name="duration">The duration, in seconds, to suspend the VPN.</param>
    /// <returns>A `Task&lt;PiaResults&gt;` containing standard output and standard error results.</returns>
    public async Task<PiaResults> Snooze(int duration, CancellationToken ct = default)
    {
        PiaResults connectionResult = await _piaCtl.GetConnectionState();
        if (connectionResult.StandardOutputResults[0].ToLower() != "connected") return connectionResult;
        
        PiaResults result = await _piaCtl.Disconnect();
        if (result.Status != Status.Completed) return result;
        
        await Task.Delay(duration * 1000, ct);
        return await _piaCtl.Connect();
    }
}