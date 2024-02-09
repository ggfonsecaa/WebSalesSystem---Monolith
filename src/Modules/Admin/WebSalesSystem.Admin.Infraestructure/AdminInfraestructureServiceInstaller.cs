namespace WebSalesSystem.Admin.Infraestructure;
internal class AdminInfraestructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _ = serviceCollection.AddScoped<IUnitOfWork<AdminDbContext>, UnitOfWork<AdminDbContext>>();
        _ = serviceCollection.AddScoped<IDbContextFactory<AdminDbContext>, AdminDbContextFactory>();

        _ = serviceCollection.AddDbContext<AdminDbContext>((provider, options) =>
        {
            AuditInterceptor auditInterceptor = provider.GetRequiredService<AuditInterceptor>();
            DomainEventsInterceptor domainEventsInterceptor = provider.GetRequiredService<DomainEventsInterceptor>();

            _ = options.UseSqlServer(configuration.GetConnectionString(nameof(AdminDbContext)), sqlOptions =>
                sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
                          .AddInterceptors(auditInterceptor, domainEventsInterceptor)
                          .EnableDetailedErrors(true);
        });
    }
}