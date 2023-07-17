using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Extensions;

namespace Cmpnnt.Pia.Test.Unit.Extensions;

[TestClass]
public class StatusExtensionsTests
{
    /// <summary>
    /// Test the output of the `ToStringF()` Status enum extension method 
    /// </summary>
    [TestMethod]
    public void ToStringF()
    {
        var s = Status.Started;
        Assert.AreEqual("Started", s.ToStringF());

        s = Status.NotStarted;
        Assert.AreEqual("NotStarted", s.ToStringF());

        s = Status.Completed;
        Assert.AreEqual("Completed", s.ToStringF());

        s = Status.Canceled;
        Assert.AreEqual("Canceled", s.ToStringF());

        s = Status.Error;
        Assert.AreEqual("Error", s.ToStringF());
    }
}