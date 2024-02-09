namespace WebSalesSystem.Shared.Infraestructure.Data;
public class AppDbContextFactory(IServiceProvider serviceProvider) : IDbContextFactory<AppDbContext>
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public AppDbContext CreateDbContext() => _serviceProvider.GetRequiredService<AppDbContext>();
}