namespace WebSalesSystem.Admin.Application;
public class AdminApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Assembly currentAssembly = Assembly.GetExecutingAssembly();

        _ = serviceCollection.AddMediatR(x => x.RegisterServicesFromAssemblies(currentAssembly));
        _ = serviceCollection.AddValidatorsFromAssembly(currentAssembly);
    }
}