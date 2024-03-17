using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Test.Unit.Lib;

[TestClass]
public class CommandRunnerTests
{

    private static Task<PiaResults> MockExecute(string command, PiaCtlOptions options, CancellationToken ct = default)
    {
        return Execute(command, options);
    }
    
    private static Task<PiaResults> MockTimedExecute(uint timeout, string command, PiaCtlOptions options)
    {
        return Execute(command, options);
    }

    private static Task<PiaResults> Execute(string command, PiaCtlOptions options)
    {
        string mockValue = options.PiaPath + " " + command;
        var result = new PiaResults
        {
            StandardOutputResults = [mockValue],
            Status = Status.Completed
        };
        return Task.FromResult(result);
    }

    readonly CommandRunner _commandRunner = new();

    private static readonly PiaCtlOptions Options = new() { PiaPath = PiaEnvironment.PiaPath };
    
    [TestMethod]
    public async Task RunArgumentless()
    {
        PiaResults results = await _commandRunner.Run(
            MockExecute, 
            Command.Background, 
            DaemonAction.Protocol, 
            Options,
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunSingleStringArgument()
    {
        PiaResults results = await _commandRunner.Run(
            MockExecute, 
            Command.Background, 
            DaemonAction.Protocol, 
            argument: "argument 1",
            Options,
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol argument 1 --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunSingleBoolArgument()
    {
        PiaResults results = await _commandRunner.Run(
            MockExecute,
            Command.Background,
            DaemonAction.Protocol,
            argument: true,
            Options,
            debug: true
        );

        var expected = $"{PiaEnvironment.PiaPath} background protocol true --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunTwoArguments()
    {
        PiaResults results = await _commandRunner.Run(
            MockExecute,
            Command.Background,
            DaemonAction.Protocol,
            argument1: "argument 1",
            argument2: "argument 2",
            Options,
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol argument 1 argument 2 --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunTimed()
    {
        PiaResults results = await _commandRunner.Run(
            MockTimedExecute,
            Command.Background,
            DaemonAction.Protocol,
            10,
            Options,
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol 10 --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
}