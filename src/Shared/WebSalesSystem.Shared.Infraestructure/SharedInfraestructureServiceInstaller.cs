namespace WebSalesSystem.Shared.Infraestructure;
public class SharedInfraestructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddScoped<IUnitOfWork<AppDbContext>, UnitOfWork<AppDbContext>>();
        _ = serviceCollection.AddScoped<IDbContextFactory<AppDbContext>, AppDbContextFactory>();
        _ = serviceCollection.AddScoped<ITenantAccessor<BaseTenant, BaseSubTenant>, TenantAccessor<BaseTenant, BaseSubTenant>>();
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
    }
}