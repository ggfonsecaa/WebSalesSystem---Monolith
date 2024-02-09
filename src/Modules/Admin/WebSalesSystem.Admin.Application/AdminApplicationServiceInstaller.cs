using WebSalesSystem.Shared.Application.Extensions.Middleware.MultiTenancy;
using WebSalesSystem.Shared.Infraestructure.Tenancy.ResolutionStrategy;
using WebSalesSystem.Shared.Infraestructure.Tenancy.Storage;

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