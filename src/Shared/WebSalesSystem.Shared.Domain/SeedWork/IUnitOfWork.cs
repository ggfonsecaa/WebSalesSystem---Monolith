namespace WebSalesSystem.Shared.Domain.SeedWork;
public interface IUnitOfWork<TDbContext> : IDisposable where TDbContext : DbContext
{
    public Task ApplyMigrationsAsync(CancellationToken cancellationToken = default);
    public Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default);
    public Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default);
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity, IAggregateRoot;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}