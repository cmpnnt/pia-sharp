using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;

namespace Cmpnnt.Pia.Test.Unit.Extensions;

[TestClass]
public class DaemonActionExtensionsTests
{
    /// <summary>
    /// Test the output of the `ToStringF()` DaemonAction enum extension method 
    /// </summary>
    [TestMethod]
    public void ToStringF()
    {
        var d = DaemonAction.AllowLan;
        Assert.AreEqual("AllowLan", d.ToStringF());

        d = DaemonAction.ConnectionState;
        Assert.AreEqual("ConnectionState", d.ToStringF());

        d = DaemonAction.DebugLogging;
        Assert.AreEqual("DebugLogging", d.ToStringF());

        d = DaemonAction.PortForward;
        Assert.AreEqual("PortForward", d.ToStringF());

        d = DaemonAction.Protocol;
        Assert.AreEqual("Protocol", d.ToStringF());

        d = DaemonAction.PubIp;
        Assert.AreEqual("PubIp", d.ToStringF());

        d = DaemonAction.Region;
        Assert.AreEqual("Region", d.ToStringF());

        d = DaemonAction.Regions;
        Assert.AreEqual("Regions", d.ToStringF());

        d = DaemonAction.RequestPortForward;
        Assert.AreEqual("RequestPortForward", d.ToStringF());
        
        d = DaemonAction.VpnIp;
        Assert.AreEqual("VpnIp", d.ToStringF());
    }
}