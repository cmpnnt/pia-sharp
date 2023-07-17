using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Test.Unit.Lib;

[TestClass]
public class CommandRunnerTests
{

    private static Task<PiaResults> MockExecute(string command, string piaPath, CancellationToken ct = default)
    {
        return Execute(command, piaPath);
    }
    
    private static Task<PiaResults> MockTimedExecute(uint timeout, string command, string piaPath)
    {
        return Execute(command, piaPath);
    }

    private static Task<PiaResults> Execute(string command, string piaPath)
    {
        string mockValue = piaPath + " " + command;
        var result = new PiaResults
        {
            StandardOutputResults = new List<string>{mockValue},
            Status = Status.Completed
        };
        return Task.FromResult(result);
    }

    [TestMethod]
    public async Task RunArgumentless()
    {
        PiaResults results = await CommandRunner.Run(
            MockExecute, 
            Command.Background, 
            DaemonAction.Protocol, 
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunSingleStringArgument()
    {
        PiaResults results = await CommandRunner.Run(
            MockExecute, 
            Command.Background, 
            DaemonAction.Protocol, 
            argument: "argument 1", 
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol argument 1 --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunSingleBoolArgument()
    {
        PiaResults results = await CommandRunner.Run(
            MockExecute,
            Command.Background,
            DaemonAction.Protocol,
            argument: true,
            debug: true
        );

        var expected = $"{PiaEnvironment.PiaPath} background protocol true --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunTwoArguments()
    {
        PiaResults results = await CommandRunner.Run(
            MockExecute,
            Command.Background,
            DaemonAction.Protocol,
            argument1: "argument 1",
            argument2: "argument 2",
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol argument 1 argument 2 --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
    
    [TestMethod]
    public async Task RunTimed()
    {
        PiaResults results = await CommandRunner.Run(
            MockTimedExecute,
            Command.Background,
            DaemonAction.Protocol,
            10,
            debug: true
        );
        
        var expected = $"{PiaEnvironment.PiaPath} background protocol 10 --debug";
        Assert.AreEqual(expected, results.StandardOutputResults[0]);
    }
}