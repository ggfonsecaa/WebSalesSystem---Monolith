namespace WebSalesSystem.Admin.Infraestructure.Data;
public class AdminDbContextFactory(IServiceProvider serviceProvider) : IDbContextFactory<AdminDbContext>
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public AdminDbContext CreateDbContext() => _serviceProvider.GetRequiredService<AdminDbContext>();
}