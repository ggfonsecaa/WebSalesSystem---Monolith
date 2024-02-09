namespace WebSalesSystem.Shared.Infraestructure.Repositories;
public class UnitOfWork<TDbContext>(IDbContextFactory<TDbContext> dbContextFactory) : IUnitOfWork<TDbContext>, IDisposable where TDbContext : DbContext
{
    private bool disposed = false;
    private readonly TDbContext _dbContext = dbContextFactory.CreateDbContext();
    private readonly Dictionary<Type, object> _repositories = [];

    public async Task ApplyMigrationsAsync(CancellationToken cancellationToken = default) => await _dbContext.Database.MigrateAsync(cancellationToken);

    public async Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default) => await _dbContext.Database.EnsureCreatedAsync(cancellationToken);

    public async Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default) => await _dbContext.Database.EnsureDeletedAsync(cancellationToken);

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity, IAggregateRoot
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        Repository<TEntity>? repository = new(_dbContext);
        _repositories.Add(typeof(TEntity), repository);

        return repository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}