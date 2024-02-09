namespace WebSalesSystem.Admin.API;
public class AdminModuleServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        //_ = serviceCollection.AddCarter();
        //_ = serviceCollection.AddMultiTenancy().WithResolutionStrategy<UrlResolutionStrategy>().WithStore<SqlStorage<DbContext>>();
        //_ = serviceCollection.AddExceptionHandler<GlobalExceptionHandler>();
        //_ = serviceCollection.AddDbContext<DbContext>(options => options.UseInMemoryDatabase("PruebasMultiTenancy"));
        _ = serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        //app.UseMultiTenancy();
    }
}