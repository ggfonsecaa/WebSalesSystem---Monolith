namespace WebSalesSystem.Shared.Infraestructure.Data;
public class AppDbContextFactory<TDbContext>(TDbContext appDbContext) : IDbContextFactory<TDbContext> where TDbContext : DbContext
{
    private readonly TDbContext _dbContext = appDbContext;

    public TDbContext CreateDbContext() => _dbContext;
}