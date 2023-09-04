using Cmpnnt.Pia.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cmpnnt.Pia.Examples;

/// <summary>
/// An example program illustrating how to use dependency injection with `Cmpnnt.Pia.Ctl` in a command-line application.
/// </summary>
public class Program
{
    // See: https://stackoverflow.com/questions/59186563/create-option-class-for-my-own-class-library#answer-59196816
    static async Task Main(String[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddPiaCtl(options =>
                {
                    // Omit this to use the default path to piactl on your system.
                    options.PiaPath = @"C:\path\to\piactl.exe";
                });
                
                // Use services.AddPiaCtl like above (with or without an options parameter) or add it as a singleton like below:
                //services.AddSingleton<PiaCtl>();
                
                // Just a sample DI-registered class which consumes cmpnnt.pia.ctl
                services.AddScoped<SomeClass>();
            })
            .ConfigureLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
            })
            .Build();
        
        await GetServiceAndRunIt(host.Services);

        await host.RunAsync();
    }
    
    /// <summary>
    /// A simple function to get the sample <see cref="SomeClass"/> from DI and invoke it.:
    /// </summary>
    /// <param name="hostProvider"></param>
    private static async Task GetServiceAndRunIt(IServiceProvider hostProvider)
    {
        using IServiceScope serviceScope = hostProvider.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        var sc = provider.GetRequiredService<SomeClass>();
        await sc.Run();
    }
}
