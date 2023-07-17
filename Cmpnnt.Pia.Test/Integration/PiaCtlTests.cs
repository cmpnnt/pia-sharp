using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Test.Integration;

/// <summary>
/// These integration tests only test whether the calls to the PiaCtl actions eventually return some result.
/// In this case, they're all error results because we can't test the actual PiaCtl daemon in an automated environment.
/// </summary>
[TestClass]
public class PiaCtlTests
{
    private readonly PiaCtl _piaCtl = new(new PiaCtlOptions{PiaPath = Helpers.CommandLinePath()});
    
    [TestMethod]
    public async Task Connect()
    {
        PiaResults results = await _piaCtl.Connect();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task Login()
    {
        PiaResults results = await _piaCtl.Login("../Resources/LoginFile.txt");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task Logout()
    {
        PiaResults results = await _piaCtl.Logout();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task Disconnect()
    {
        PiaResults results = await _piaCtl.Disconnect();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task ResetSettings()
    {
        PiaResults results = await _piaCtl.ResetSettings();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task AddDedicatedIp()
    {
        PiaResults results = await _piaCtl.AddDedicatedIp("a/fake/path");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task RemoveDedicatedIp()
    {
        PiaResults results = await _piaCtl.RemoveDedicatedIp("fakeRegionId");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task BackgroundEnable()
    {
        PiaResults results = await _piaCtl.BackgroundEnable();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task BackgroundDisable()
    {
        PiaResults results = await _piaCtl.BackgroundDisable();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task SetAllowLan()
    {
        PiaResults results = await _piaCtl.SetAllowLan(true);
        /* The set methods don't return error output because these tests pass the commands to the
         OS shell and "set" is a valid command on both Linux and Windows */
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetDebugLogging()
    {
        PiaResults results = await _piaCtl.SetDebugLogging(true);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetProtocol()
    {
        PiaResults results = await _piaCtl.SetProtocol("fakeValue");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetRegion()
    {
        PiaResults results = await _piaCtl.SetRegion("fakeValue");
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task SetRequestPortForward()
    {
        PiaResults results = await _piaCtl.SetRequestPortForward(true);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Completed, results.Status);
    }
    
    [TestMethod]
    public async Task GetAllowLan()
    {
        PiaResults results = await _piaCtl.GetAllowLan();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetConnectionState()
    {
        PiaResults results = await _piaCtl.GetConnectionState();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetDebugLogging()
    {
        PiaResults results = await _piaCtl.GetDebugLogging();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetPortForward()
    {
        PiaResults results = await _piaCtl.GetPortForward();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetProtocol()
    {
        PiaResults results = await _piaCtl.GetProtocol();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetPubIp()
    {
        PiaResults results = await _piaCtl.GetPubIp();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetRegion()
    {
        PiaResults results = await _piaCtl.GetRegion();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetRegions()
    {
        PiaResults results = await _piaCtl.GetRegions();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetRequestPortForward()
    {
        PiaResults results = await _piaCtl.GetRequestPortForward();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task GetVpnIp()
    {
        PiaResults results = await _piaCtl.GetVpnIp();
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreNotEqual(0, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorAllowLan()
    {
        PiaResults results = await _piaCtl.MonitorAllowLan(1);
        // Assert.AreEqual(0, results.StandardOutputResults.Count);
        // Assert.AreEqual(8, results.StandardErrorResults.Count);
        //Assert.AreEqual(Status.Error, results.Status);
        Console.WriteLine(results);
    }
    
    [TestMethod]
    public async Task MonitorConnectionState()
    {
        PiaResults results = await _piaCtl.MonitorConnectionState(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorDebugLogging()
    {
        PiaResults results = await _piaCtl.MonitorDebugLogging(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorPortForward()
    {
        PiaResults results = await _piaCtl.MonitorPortForward(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorProtocol()
    {
        PiaResults results = await _piaCtl.MonitorProtocol(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorPubIp()
    {
        PiaResults results = await _piaCtl.MonitorPubIp(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorRegion()
    {
        PiaResults results = await _piaCtl.MonitorPubIp(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorRequestPortForward()
    {
        PiaResults results = await _piaCtl.MonitorRequestPortForward(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
    
    [TestMethod]
    public async Task MonitorVpnIp()
    {
        PiaResults results = await _piaCtl.MonitorVpnIp(3);
        Assert.AreEqual(0, results.StandardOutputResults.Count);
        Assert.AreEqual(8, results.StandardErrorResults.Count);
        Assert.AreEqual(Status.Error, results.Status);
    }
}