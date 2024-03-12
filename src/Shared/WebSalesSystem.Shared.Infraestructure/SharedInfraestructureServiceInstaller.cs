namespace WebSalesSystem.Shared.Infraestructure;
public class SharedInfraestructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddScoped<GlobalizationMiddleware>();
        _ = serviceCollection.AddScoped<MultiTenancyMiddleware>();
        _ = serviceCollection.AddScoped<ITenantAccessor, TenantAccessor>();
        _ = serviceCollection.AddScoped<AuditInterceptor>();
        _ = serviceCollection.AddScoped<TenantInterceptor>();
        _ = serviceCollection.AddScoped<DomainEventsInterceptor>();

        _ = serviceCollection.AddDbContext<AppDbContext>((provider, options) =>
        {
            AuditInterceptor auditInterceptor = provider.GetRequiredService<AuditInterceptor>();
            TenantInterceptor tenantInterceptor = provider.GetRequiredService<TenantInterceptor>();
            DomainEventsInterceptor domainEventsInterceptor = provider.GetRequiredService<DomainEventsInterceptor>();

            _ = options.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext)), sqlOptions =>
                sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
                          .AddInterceptors(auditInterceptor, domainEventsInterceptor)
                          .EnableDetailedErrors(true);
        });

        _ = serviceCollection.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        _ = serviceCollection.AddScoped(typeof(IDbContextFactory<>), typeof(AppDbContextFactory<>));
    }
}