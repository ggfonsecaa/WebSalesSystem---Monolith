namespace WebSalesSystem.Admin.Infraestructure;
internal class AdminInfraestructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddDbContext<AdminDbContext>();
    }
}