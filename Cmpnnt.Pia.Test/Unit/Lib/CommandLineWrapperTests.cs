using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Test.Unit.Lib;

[TestClass]
public class CommandLineWrapperTests
{
    private const string Command = "echo hello";
    private const string ErrorCommand = "I throw an error.";
    private const string ShortTimedCommand = "sleep 1; echo hello";
    private const string LongTimedCommand = "sleep 3; echo hello";
    private readonly CommandLineWrapper _commandLineWrapper = new();
    private static readonly PiaCtlOptions Options = new() { PiaPath = Helpers.CommandLinePath() };
    
    [TestMethod]
    public async Task CompletedExecution()
    {
        if (Helpers.OperatingSystem() == Os.Windows)
        {
            PiaResults results = await _commandLineWrapper.Execute(Command, Options);
            Assert.AreEqual("hello", results.StandardOutputResults[0]);
            Assert.AreEqual(0, results.StandardErrorResults.Count);
            Assert.AreEqual(Status.Completed, results.Status);
        }
    }
    
    [TestMethod]
    public async Task CompletedTimedExecution()
    {

        if (Helpers.OperatingSystem() == Os.Windows)
        {
            PiaResults results = await _commandLineWrapper.ExecuteTimed(5, ShortTimedCommand, Options);
            Assert.AreEqual(Status.Completed, results.Status);
            Assert.AreEqual("hello", results.StandardOutputResults[0]);
            Assert.AreEqual(0, results.StandardErrorResults.Count);
        }
    }
    
    [TestMethod]
    public async Task CanceledExecution()
    {
        CancellationTokenSource cts = new();
        cts.CancelAfter(TimeSpan.FromSeconds(1));
        CancellationToken ct = cts.Token;

        if (Helpers.OperatingSystem() == Os.Windows)
        {
            // Use the `TimedCommand` to simulate a long-running task to cancel
            PiaResults results = await _commandLineWrapper.Execute(LongTimedCommand, Options, ct: ct);
            Console.WriteLine(results.ToString());
            Assert.AreEqual(Status.Canceled, results.Status);
            Assert.AreEqual(0, results.StandardOutputResults.Count);
            Assert.AreEqual(0, results.StandardErrorResults.Count);
        }
    }

    [TestMethod]
    public async Task ErroredExecution()
    {
        PiaResults results = await _commandLineWrapper.Execute(ErrorCommand, Options);
        string errorMessage = (Helpers.OperatingSystem() == Os.Windows) ? "is not recognized" : "no such file";
        Assert.IsTrue(results.StandardErrorResults[0].Contains(errorMessage, StringComparison.CurrentCultureIgnoreCase));
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task ErroredExecutionTimed()
    {
        PiaResults results = await _commandLineWrapper.ExecuteTimed(1, ErrorCommand, Options);
        string errorMessage = (Helpers.OperatingSystem() == Os.Windows) ? "is not recognized" : "no such file";
        Assert.IsTrue(results.StandardErrorResults[0].Contains(errorMessage, StringComparison.CurrentCultureIgnoreCase));
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
}
