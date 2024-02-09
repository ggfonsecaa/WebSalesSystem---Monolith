namespace WebSalesSystem.Admin.API;
public class AdminModuleInstaller : IModuleInstaller
{
    public IServiceCollection Install(IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies.SelectMany(x => x.DefinedTypes).Where(IsAssignableToType<IServiceInstaller>).Select(Activator.CreateInstance).Cast<IServiceInstaller>();

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(serviceCollection, configuration);
        }

        return serviceCollection;
    }

    public IServiceCollection Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Assembly[] assemblies = [AdminDomainReference.Assembly, AdminInfraestructureReference.Assembly, AdminApplicationReference.Assembly, Assembly.GetExecutingAssembly()]; 
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies.SelectMany(x => x.DefinedTypes).Where(IsAssignableToType<IServiceInstaller>).Select(Activator.CreateInstance).Cast<IServiceInstaller>();

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(serviceCollection, configuration);
        }

        return serviceCollection;
    }

    private static bool IsAssignableToType<T>(TypeInfo typeInfo) => typeof(T).IsAssignableFrom(typeInfo) && !typeInfo.IsInterface && !typeInfo.IsAbstract;

    public void Configure(IApplicationBuilder app)
    {

    }

    public void Configure(IApplicationBuilder app, params Assembly[] assemblies)
    {

    }
}