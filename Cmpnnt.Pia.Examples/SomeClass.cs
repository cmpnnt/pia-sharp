using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Lib.Results;
using Microsoft.Extensions.Logging;

namespace Cmpnnt.Pia.Examples;

/// <summary>
/// An simple class used as a dummy service for the dependency injection example code.
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
        PiaResults result = await _pia.GetProtocol();
        _logger.LogInformation("{msg}", result.ToString());
    }
}