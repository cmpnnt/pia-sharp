using Cmpnnt.Pia.Ctl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cmpnnt.Pia.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    
    /// <summary>
    /// An IServiceCollection extension method that registers `Cmpnnt.Pia.Ctl` and `PiaCtlOptions` as singletons.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configureOptions"></param>
    /// <returns></returns>
    public static IServiceCollection AddPiaCtl(
        this IServiceCollection services, 
        Action<PiaCtlOptions>? configureOptions = default)
    {
        // See: https://stackoverflow.com/questions/59186563/create-option-class-for-my-own-class-library#answer-59196816
        configureOptions ??= pco => { };
        services.AddOptions<PiaCtlOptions>().Configure(configureOptions);
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<PiaCtlOptions>>().Value);
        services.AddSingleton<PiaCtl>();
        return services;
    }
}
