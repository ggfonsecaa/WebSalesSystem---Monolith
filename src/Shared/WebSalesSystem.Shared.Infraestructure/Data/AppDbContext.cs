namespace WebSalesSystem.Shared.Infraestructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options, ITenantAccessor tenantAccessor, DomainEventsInterceptor domainEventsInterceptor, AuditInterceptor auditInterceptor, TenantInterceptor tenantInterceptor) : DbContext(options)
{
    protected readonly ITenantAccessor _tenantAccessor = tenantAccessor;
    protected readonly AuditInterceptor _auditInterceptor = auditInterceptor;
    protected readonly TenantInterceptor _tenantInterceptor = tenantInterceptor;
    protected readonly DomainEventsInterceptor _domainEventsInterceptor = domainEventsInterceptor;
    protected string? ConnectionString { get; set; }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) => configurationBuilder.Properties<string>().HaveColumnType("varchar");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        _ = optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        //switch (_tenantAccessor.Tenant!.Configuration.DbProvider.Name)
        //{
        //    case "InMemory":
        //        _ = optionsBuilder.UseInMemoryDatabase(nameof(AppDbContext));
        //        break;

        //    case "SqlSever":
        //        ConnectionString = _tenantAccessor.GetConnectionString(nameof(AppDbContext));

        //        _ = optionsBuilder.UseSqlServer(ConnectionString, sqlOptions
        //                => sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
        //                        .AddInterceptors(_auditInterceptor, _tenantInterceptor, _domainEventsInterceptor)
        //                        .EnableDetailedErrors(true);
        //        break;

        //    case "Oracle":
        //        break;

        //    case "PostgreSQL":
        //        break;

        //    default:
        //        break;
        //}


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<ITenantEntity>().HasQueryFilter(x => EF.Property<int>(x, "TenantId") == _tenantAccessor.Tenant!.Id);

        //foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
        //{
        //    Type? type = entity.ClrType;

        //    if (typeof(ITenantEntity).IsAssignableFrom(type))
        //    {
        //        MethodInfo? method = typeof(AppDbContext).GetMethod(nameof(GlobalFilterTenant), BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(type);

        //        object? filter = method?.Invoke(null, new object[] { this })!;
        //        entity.SetQueryFilter((Expression<Func<object, bool>>)filter);
        //    }
        //    else if (type.SkipTenantValidation())
        //    {
        //        continue;
        //    }
        //    else
        //    {
        //        throw new Exception($"Entity {entity} has not been marked as tenant or common yet");
        //    }
        //}

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private static Expression<Func<TEntity, bool>> GlobalFilterTenant<TEntity>(AppDbContext context) where TEntity : Entity, ITenantEntity
    {
        Expression<Func<TEntity, bool>> filter = x => x.TenantId == context._tenantAccessor.Tenant!.Id;
        //<Func<TEntity, bool>> filter = x => x.TenantId == 1;
        return filter;
    }
}