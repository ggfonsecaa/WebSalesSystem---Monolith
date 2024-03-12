namespace WebSalesSystem.Shared.Domain;
public class SharedDomainServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddScoped<CultureProvider>();
        _ = serviceCollection.AddExceptionHandler<GlobalExceptionHandler>();
    }
}