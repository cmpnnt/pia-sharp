using Cmpnnt.Pia.Ctl;

namespace Cmpnnt.Pia.Test.Unit.Lib;

[TestClass]
public class PiaCtlOptionsTests
{
    [TestMethod]
    public void TestPiaPathProperty()
    {
        PiaCtlOptions options = new()
        {
            PiaPath = @"C:\Program Files\Private Internet Access\piactl.exe"
        };
        
        Assert.AreEqual(@"C:\Program Files\Private Internet Access\piactl.exe", options.PiaPath);
    }
}
