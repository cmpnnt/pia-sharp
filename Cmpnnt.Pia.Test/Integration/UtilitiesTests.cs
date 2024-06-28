using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;
using NSubstitute;

namespace Cmpnnt.Pia.Test.Integration;

using Cmpnnt.Pia.Ctl;

[TestClass]
public class UtilitiesTests
{
    
    private static readonly PiaCtlOptions Options = new() { PiaPath = Helpers.CommandLinePath() };

    [TestMethod]
    public async Task SwitchToFastest_ValidRegion()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults regionResults = new();
        regionResults.Status = Status.Completed;
        regionResults.StandardOutputResults = Regions();
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(regionResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        Utilities utilities = new Utilities(piaCtl);

        PiaResults switchToFastestResults = await utilities.SwitchToFastest(MultiRegion.US);
        
        Assert.AreEqual(Status.Completed, switchToFastestResults.Status);
        Assert.AreEqual("us-rhode-island", switchToFastestResults.StandardOutputResults[0]);
        Assert.AreEqual(0, switchToFastestResults.StandardErrorResults.Count);
    }
    
    [TestMethod]
    public async Task SwitchToFastest_NoneFound()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults regionResults = new();
        regionResults.Status = Status.Completed;
        regionResults.StandardOutputResults = Regions();
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(regionResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        Utilities utilities = new Utilities(piaCtl);

        PiaResults switchToFastestResults = await utilities.SwitchToFastest(MultiRegion.AU);
        
        Assert.AreEqual(Status.Error, switchToFastestResults.Status);
        Assert.AreEqual("Unable to switch to a new region.", switchToFastestResults.StandardErrorResults[0]);
        Assert.AreEqual(0, switchToFastestResults.StandardOutputResults.Count);
    }

    private List<string> Regions()
    {
        return ["auto", "us-rhode-island", "us-maine", "us-south-carolina", "uk-london", "es-madrid"];
    }
    
}