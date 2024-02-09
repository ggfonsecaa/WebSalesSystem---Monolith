namespace WebSalesSystem.Shared.Domain;
public class SharedDomainServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddExceptionHandler<GlobalExceptionHandler>();
    }
}