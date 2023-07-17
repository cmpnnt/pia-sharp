using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Test.Unit.Lib;

[TestClass]
public class CommandLineWrapperTests
{
    private const string Command = "echo hello";
    private const string ErrorCommand = "I throw an error.";
    private const string TimedCommand = "sleep 2; echo hello";
    
    [TestMethod]
    public async Task CompletedExecution()
    {
        PiaResults results = await CommandLineWrapper.Execute(Command, Helpers.CommandLinePath());
        Assert.AreEqual("hello", results.StandardOutputResults[0]);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task CompletedTimedExecution()
    {
        PiaResults results = await CommandLineWrapper.ExecuteTimed(4, TimedCommand, Helpers.CommandLinePath());
        Assert.AreEqual(Status.Completed, results.Status);
        Assert.AreEqual("hello", results.StandardOutputResults[0]);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Console.WriteLine(results);
    }
    
    [TestMethod]
    public async Task CanceledExecution()
    {
        CancellationTokenSource cts = new();
        cts.CancelAfter(TimeSpan.FromSeconds(1));
        CancellationToken ct = cts.Token;

        // Use the `TimedCommand` to simulate a long-running task to cancel
        PiaResults results = await CommandLineWrapper.Execute(TimedCommand, Helpers.CommandLinePath(), ct: ct);
        Console.WriteLine(results.ToString());
        Assert.AreEqual(Status.Canceled, results.Status);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
    }

    [TestMethod]
    public async Task ErroredExecution()
    {
        PiaResults results = await CommandLineWrapper.Execute(ErrorCommand, Helpers.CommandLinePath());
        Assert.IsTrue(results.StandardErrorResults[0].Contains("is not recognized"));
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task ErroredExecutionTimed()
    {
        PiaResults results = await CommandLineWrapper.ExecuteTimed(3, ErrorCommand, Helpers.CommandLinePath());
        Assert.IsTrue(results.StandardErrorResults[0].Contains("is not recognized"));
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
}