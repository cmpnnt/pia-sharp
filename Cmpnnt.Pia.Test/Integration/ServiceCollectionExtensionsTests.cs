using Cmpnnt.Pia.Ctl;
using Cmpnnt.Pia.Ctl.Lib;
using Cmpnnt.Pia.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cmpnnt.Pia.Test.Integration;

[TestClass]
public class ServiceCollectionExtensionsTests
{

    /// <summary>
    /// Tests whether AddPiaCtl registers the required services with the DI container.
    /// </summary>
    [TestMethod]
    public void AddPiaCtl_Default_Path()
    {
        var services = new ServiceCollection();
        services.AddPiaCtl();
        ServiceProvider provider = services.BuildServiceProvider();
        Assert.AreEqual(1, provider.GetServices<PiaCtl>().Count());
        Assert.AreEqual(1, provider.GetServices<PiaCtlOptions>().Count());
        Assert.AreEqual(PiaEnvironment.PiaPath, provider.GetRequiredService<PiaCtlOptions>().PiaPath);
    }
    
    /// <summary>
    /// Tests whether AddPiaCtl registers the required services with the DI container.
    /// </summary>
    [TestMethod]
    public void AddPiaCtl_Custom_Path()
    {
        var services = new ServiceCollection();

        if (Helpers.OperatingSystem() == Os.Windows || Helpers.OperatingSystem() == Os.Linux)
        {
            services.AddPiaCtl(options =>
            {
                options.PiaPath = PiaEnvironment.PiaPath;
            });
        }
        else if(Helpers.OperatingSystem() == Os.MacOs)
        {
            throw new ArgumentException("MacOS is currently unsupported because of limitations in .NET 7.");
        }
        else
        {
            throw new ArgumentException("Unknown operating system");
        }
        
        ServiceProvider provider = services.BuildServiceProvider();
        Assert.AreEqual(1, provider.GetServices<PiaCtl>().Count());
        Assert.AreEqual(1, provider.GetServices<PiaCtlOptions>().Count());
        Assert.AreEqual(PiaEnvironment.PiaPath, provider.GetRequiredService<PiaCtlOptions>().PiaPath);
    }
}