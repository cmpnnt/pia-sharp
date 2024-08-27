using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Lib.Results;
using Microsoft.Extensions.Logging;

namespace Cmpnnt.Pia.Examples;

/// <summary>
/// A simple class used as a dummy service for the dependency injection example code.
/// </summary>
public class SomeClass
{
    private readonly PiaCtl _pia;
    private readonly ILogger<SomeClass> _logger;

    public SomeClass(PiaCtl pia, ILogger<SomeClass> logger)
    {
        _pia = pia;
        _logger = logger;
    }

    /// <summary>
    /// Executes a PIA command and logs the results.
    /// </summary>
    public async Task Run()
    {
        var u = new Utilities(_pia);
        PiaResults result = await u.Snooze(20);
        _logger.LogInformation("{msg}", result.ToString());
    }
}