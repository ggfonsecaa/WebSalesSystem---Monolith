namespace WebSalesSystem.Shared.Domain.SeedWork;
public interface IServiceInstaller
{
    void Install(IServiceCollection serviceCollection, IConfiguration configuration);
}