namespace WebSalesSystem.Shared.API;
public class SharedModuleServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddCarter();       
        _ = serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        //app.UseMultiTenancy();
    }
}