using Cmpnnt.Pia.Ctl.Enums;
using Cmpnnt.Pia.Ctl.Lib.Results;

namespace Cmpnnt.Pia.Test.Unit.Lib.Results;

[TestClass]
public class PiaResultsTests
{
    /// <summary>
    /// Test the default state of a PiaResults object
    /// </summary>
    [TestMethod]
    public void DefaultValues()
    {
        PiaResults results = new();
        Assert.AreEqual(0, results.StandardOutputResults?.Count);
        Assert.AreEqual(0, results.StandardErrorResults?.Count);
        Assert.AreEqual(Status.NotStarted, results.Status);
    }
    
    /// <summary>
    /// Test the serialized output of an empty PiaResults object
    /// </summary>
    [TestMethod]
    public void ToString_Serialize_Empty()
    {
        PiaResults results = new();
        string serialized = 
        """
        {
          "StandardOutputResults": [],
          "StandardErrorResults": [],
          "Status": "NotStarted"
        }
        """;
        
        Assert.AreEqual(results.ToString(), serialized);
    }
    
    /// <summary>
    /// Test the serialized output of a PiaResults object with an empty `StandardErrorResults` list
    /// </summary>
    [TestMethod]
    public void ToString_Serialize_EmptyError()
    {
        PiaResults results = new();
        results.Status = Status.Completed;
        results.StandardOutputResults.Add("Item 1");
        results.StandardOutputResults.Add("Item 2");

        string serialized = 
            """
        {
          "StandardOutputResults": [
            "Item 1",
            "Item 2"
          ],
          "StandardErrorResults": [],
          "Status": "Completed"
        }
        """;
        Assert.AreEqual(results.ToString(), serialized);
    }
    
    /// <summary>
    /// Test the serialized output of a fully populated PiaResults object
    /// </summary>
    [TestMethod]
    public void ToString_Serialize_Full()
    {
        PiaResults results = new();
        results.Status = Status.Completed;
        results.StandardOutputResults.Add("Item 1");
        results.StandardOutputResults.Add("Item 2");
        results.StandardErrorResults.Add("Item 1");
        results.StandardErrorResults.Add("Item 2");

        string serialized = 
        """
        {
          "StandardOutputResults": [
            "Item 1",
            "Item 2"
          ],
          "StandardErrorResults": [
            "Item 1",
            "Item 2"
          ],
          "Status": "Completed"
        }
        """;
        Assert.AreEqual(results.ToString(), serialized);
    }
}