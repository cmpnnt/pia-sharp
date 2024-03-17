using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.Ctl.Lib.Results;
using NSubstitute;

namespace Cmpnnt.Pia.Test.Integration;

/// <summary>
/// These integration tests only test whether the calls to the PiaCtl actions eventually return some result.
/// In this case, they're all error results because we can't test the actual PiaCtl daemon in an automated environment.
/// </summary>
[TestClass]
public class PiaCtlTests
{
    private static readonly PiaCtlOptions Options = new() { PiaPath = Helpers.CommandLinePath() };
    
    [TestMethod]
    public async Task Connect()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Started;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
            ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.Connect();
        
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Started, results.Status);
    }
    
    [TestMethod]
    public async Task Login()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Started;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.Login("../Resources/LoginFile.txt");
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Started, results.Status);
    }
    
    [TestMethod]
    public async Task Logout()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.Logout();
        // Assert.AreEqual(0, results.StandardOutputResults.Count());
        // Assert.AreNotEqual(0, results.StandardErrorResults.Count());
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task Disconnect()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.Disconnect();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task ResetSettings()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.ResetSettings();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task AddDedicatedIp()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.AddDedicatedIp("a/fake/path");
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task RemoveDedicatedIp()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.NotStarted;
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.RemoveDedicatedIp("fakeRegionId");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.NotStarted, results.Status);
    }
    
    [TestMethod]
    public async Task BackgroundEnable()
    {
        
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.BackgroundEnable();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task BackgroundDisable()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.BackgroundDisable();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetAllowLan()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.SetAllowLan(true);
        
        /* The set methods don't return error output because these tests pass the commands to the
         OS shell and "set" is a valid command on both Linux and Windows */
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetDebugLogging()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.SetDebugLogging(true);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetProtocol()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.SetProtocol("fakeValue");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetRegion()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.SetRegion("fakeValue");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetRequestPortForward()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.SetRequestPortForward(true);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetAllowLan()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetAllowLan();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetConnectionState()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetConnectionState();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetDebugLogging()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetDebugLogging();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetPortForward()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetPortForward();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetProtocol()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetProtocol();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetPubIp()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetPubIp();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetRegion()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetRegion();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetRegions()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetRegions();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetRequestPortForward()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetRequestPortForward();
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetVpnIp()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.Execute(Command.Connect.ToStringF(),
            Options,
            CancellationToken.None
        ).ReturnsForAnyArgs(Task.FromResult(piaResults));

        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.GetVpnIp();
        
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorAllowLan()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorAllowLan(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorConnectionState()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        
        PiaResults results = await piaCtl.MonitorConnectionState(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorDebugLogging()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorDebugLogging(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorPortForward()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorPortForward(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorProtocol()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorProtocol(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorPubIp()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorPubIp(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorRegion()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorPubIp(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorRequestPortForward()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorRequestPortForward(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorVpnIp()
    {
        var wrapper = Substitute.For<ICommandLineWrapper>();

        PiaResults piaResults = new();
        piaResults.Status = Status.Completed;
        piaResults.StandardErrorResults.Add("An error.");
        piaResults.StandardOutputResults.Add("Not an error.");
        
        wrapper.ExecuteTimed(10,
            Command.Monitor.ToStringF(),
            Options
        ).ReturnsForAnyArgs(piaResults);
        
        PiaCtl piaCtl = new(Options, wrapper);
        PiaResults results = await piaCtl.MonitorVpnIp(3);
        Assert.AreEqual(1, results.StandardOutputResults.Count);
        Assert.AreEqual(1, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
}