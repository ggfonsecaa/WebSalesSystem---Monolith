namespace WebSalesSystem.Shared.Domain.SeedWork;
public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
{
    public Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity?>> GetByQueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "", bool asTracking = false, bool asTrackingWithIdentity = true, bool asSingleQuery = true, CancellationToken cancellationToken = default);
    public Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    public Task<TEntity> PatchAsync(int id, JsonPatchDocument<TEntity> entity, CancellationToken cancellationToken = default);
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task<TEntity> UpdateByIdAsync(int id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}