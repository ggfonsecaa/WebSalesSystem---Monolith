using Microsoft.EntityFrameworkCore;

namespace WebSalesSystem.Shared.Application;
public class SharedApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration) 
    {
        _ = serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        _ = serviceCollection.AddDbContext<DbContext>(options => options.UseInMemoryDatabase("Pruebas"));
        _ = serviceCollection.AddMultiTenancy().WithResolutionStrategy<UrlResolutionStrategy>().WithStore<SqlStorage<DbContext>>();
    }
}