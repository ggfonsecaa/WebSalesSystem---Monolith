namespace WebSalesSystem.Shared.Infraestructure.Data;
public class AppDbContext(DbContextOptions options, IConfiguration configuration, DomainEventsInterceptor? domainEventsInterceptor = null, AuditInterceptor? auditInterceptor = null, TenantInterceptor? tenantInterceptor = null) : DbContext(options)
{
    protected readonly IConfiguration _configuration = configuration;
    protected readonly AuditInterceptor? _auditInterceptor = auditInterceptor;
    protected readonly DomainEventsInterceptor? _domainEventsInterceptor = domainEventsInterceptor;
    protected readonly TenantInterceptor? _tenantInterceptor = tenantInterceptor;
    //protected readonly int _currentUserId;
    //protected readonly BaseTenant? _tenant;

    protected string? DbContextConnectionString { get; set; }
    //protected AuditInterceptor AuditInterceptor { get; init; } = serviceProvider.GetRequiredService<AuditInterceptor>();
    //protected TenantInterceptor TenantInterceptor { get; init; } = serviceProvider.GetRequiredService<TenantInterceptor>();
    //protected DomainEventsInterceptor DomainEventsInterceptor { get; init; } = serviceProvider.GetRequiredService<DomainEventsInterceptor>();


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) => configurationBuilder.Properties<string>().HaveColumnType("varchar");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        _ = optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //string contextName = optionsBuilder.Options.ContextType.Name;

        //ConnectionString = _configuration.GetConnectionString($"{contextName}Tenant")!.Replace("{dbName}", $@"{_tenant.DbPrefix}{contextName.Replace("DbContext", "")}");
        //ConnectionString = _configuration.GetConnectionString("AdminDbContext");

        //_ = optionsBuilder.UseSqlServer(ConnectionString, sqlOptions 
        //        => sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
        //                .AddInterceptors(AuditInterceptor, TenantInterceptor, DomainEventsInterceptor)
        //                .EnableDetailedErrors(true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<ITenantEntity>().HasQueryFilter(x => EF.Property<int>(x, "TenantId") == 0);

        foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
        {
            Type? type = entity.ClrType;

            if (typeof(ITenantEntity).IsAssignableFrom(type))
            {
                MethodInfo? method = typeof(AppDbContext).GetMethod(nameof(GlobalFilterTenant), BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(type);

                object? filter = method?.Invoke(null, new object[] { this })!;
                entity.SetQueryFilter((Expression<Func<object, bool>>)filter);
            }
            else if (type.SkipTenantValidation())
            {
                continue;
            }
            else
            {
                throw new Exception($"Entity {entity} has not been marked as tenant or common yet");
            }
        }

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private static Expression<Func<TEntity, bool>> GlobalFilterTenant<TEntity>(AppDbContext context) where TEntity : Entity, ITenantEntity
    {
        //Expression<Func<TEntity, bool>> filter = x => x.TenantId == context._tenant.Id;
        Expression<Func<TEntity, bool>> filter = x => x.TenantId == 0;
        return filter;
    }
}