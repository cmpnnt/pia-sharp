using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;

namespace Cmpnnt.Pia.Test.Unit.Extensions;

[TestClass]
public class CommandExtensionsTests
{
    /// <summary>
    /// Test the output of the `ToStringF()` Command enum extension method 
    /// </summary>
    [TestMethod]
    public void ToStringF()
    {
        Command c = Command.Background;
        Assert.AreEqual("Background", c.ToStringF());
        
        c = Command.Connect;
        Assert.AreEqual("Connect", c.ToStringF());
        
        c = Command.DedicatedIp;
        Assert.AreEqual("DedicatedIp", c.ToStringF());
        
        c = Command.Disconnect;
        Assert.AreEqual("Disconnect", c.ToStringF());
        
        c = Command.Get;
        Assert.AreEqual("Get", c.ToStringF());
        
        c = Command.Login;
        Assert.AreEqual("Login", c.ToStringF());
        
        c = Command.Logout;
        Assert.AreEqual("Logout", c.ToStringF());
        
        c = Command.Monitor;
        Assert.AreEqual("Monitor", c.ToStringF());
        
        c = Command.ResetSettings;
        Assert.AreEqual("ResetSettings", c.ToStringF());
        
        c = Command.Set;
        Assert.AreEqual("Set", c.ToStringF());
    }
}