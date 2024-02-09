namespace WebSalesSystem.Admin.Infraestructure.Data;
public class AdminDbContext(DbContextOptions<AdminDbContext> options, IConfiguration configuration, DomainEventsInterceptor domainEventsInterceptor, AuditInterceptor auditInterceptor) : AppDbContext(options, configuration, domainEventsInterceptor, auditInterceptor)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        //_ = optionsBuilder.UseSqlServer(DbContextConnectionString, sqlOptions
        //    => sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
        //            .AddInterceptors(_auditInterceptor!, _domainEventsInterceptor!)
        //            .EnableDetailedErrors(true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}