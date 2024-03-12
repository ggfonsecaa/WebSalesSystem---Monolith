namespace WebSalesSystem.Shared.Domain.SeedWork;
public interface IModuleInstaller
{
    public IServiceCollection Install(IServiceCollection serviceCollection, IConfiguration configuration);
    public IServiceCollection Install(IServiceCollection serviceCollection, IConfiguration configuration, params Assembly[] assemblies);

    public void Configure(IApplicationBuilder applicationBuilder);
    public void Configure(IApplicationBuilder applicationBuilder, params Assembly[] assemblies);
}