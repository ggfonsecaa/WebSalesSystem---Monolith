namespace WebSalesSystem.Admin.Infraestructure.Data;
public class AdminDbContext(DbContextOptions<AdminDbContext> options, IConfiguration configuration, DomainEventsInterceptor domainEventsInterceptor) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<SubTenant> SubTenants => Set<SubTenant>();


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) => configurationBuilder.Properties<string>().HaveColumnType("varchar");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        _ = optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        _ = optionsBuilder.UseSqlServer(configuration.GetConnectionString(nameof(AdminDbContext)), sqlOptions
            => sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
                    .AddInterceptors(domainEventsInterceptor) // poner el interceptor de auditoria
                    .EnableDetailedErrors(true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}