namespace WebSalesSystem.App.Extensions;

public static class ModuleInstallerExtension
{
    public static IServiceCollection AddModule<T>(this IServiceCollection services, IConfiguration configuration) where T : IModuleInstaller
    {
        MethodInfo? method = typeof(T).GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(x => x.Name == "Install" && x.GetParameters().Length == 2)!;
        _ = method?.Invoke(null, new object[] { services, configuration })!;

        return services;
    }

    public static IServiceCollection AddModulesFrom(this IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] assemblies)
    {
        IEnumerable<Type>? installerTypes = assemblies.SelectMany(assembly => assembly.GetTypes()).Where(type => !type.IsAbstract && !type.IsInterface && typeof(IModuleInstaller).IsAssignableFrom(type));

        foreach (Type installerType in installerTypes)
        {
            IModuleInstaller installer = (IModuleInstaller)Activator.CreateInstance(installerType)!;
            _ = installer.Install(serviceCollection, configuration);
        }

        return serviceCollection;
    }

    public static IApplicationBuilder ConfigureServicesFrom(this IApplicationBuilder app, params Assembly[] assemblies)
    {
        IEnumerable<Type>? configurerTypes = assemblies.SelectMany(assembly => assembly.GetTypes()).Where(type => !type.IsAbstract && !type.IsInterface && typeof(IModuleInstaller).IsAssignableFrom(type));

        foreach (Type configurerType in configurerTypes)
        {
            IModuleInstaller configurer = (IModuleInstaller)Activator.CreateInstance(configurerType)!;
            configurer.Configure(app);
        }

        return app;
    }
}