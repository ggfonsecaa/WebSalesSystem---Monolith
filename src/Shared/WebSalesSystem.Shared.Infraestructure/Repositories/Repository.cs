namespace WebSalesSystem.Shared.Infraestructure.Repositories;
internal class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    private static readonly char[] _separator = [','];

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        TEntity? entity = await _dbSet.FindAsync([id], cancellationToken);
        await DeleteAsync(entity!, cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default) 
        => await Task.Run(() => 
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _ = _dbSet.Attach(entity);
                }
                _ = _dbSet.Remove(entity);

            }, cancellationToken);

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) 
        => await Task.Run(() =>
            {
                if (_dbContext.Entry(entities).State == EntityState.Detached)
                {
                    _dbSet.AttachRange(entities);
                }
                _dbSet.RemoveRange(entities);

            }, cancellationToken);

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync([id], cancellationToken);

    public async Task<IEnumerable<TEntity?>> GetByQueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "", bool asTracking = false, bool asTrackingWithIdentity = true, bool asSingleQuery = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (string includeProperty in includeProperties.Split(_separator, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (!asSingleQuery)
        {
            query = query.AsSplitQuery();
        }

        query = asTracking ? query.AsTracking() : asTrackingWithIdentity ? query.AsNoTrackingWithIdentityResolution() : query.AsNoTracking();

        return orderBy != null ? await orderBy(query).ToListAsync(cancellationToken) : (IEnumerable<TEntity?>)await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _ = await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) 
        => await Task.Run(() =>
            {
                _ = _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                return entity;
            }, cancellationToken);

    public async Task<TEntity> UpdateByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        TEntity? entity = await _dbSet.FindAsync([id], cancellationToken);

        if (entity is not null)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        return entity!;
    }

    public async Task<TEntity> PatchAsync(int id, JsonPatchDocument<TEntity> entity, CancellationToken cancellationToken = default)
    {
        TEntity? patchEntity = await _dbSet.FindAsync([id], cancellationToken);

        if (patchEntity is not null)
        {
            entity.ApplyTo(patchEntity);
        }
    
        return patchEntity!;
    }

    public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) 
        => await Task.Run(() =>
            {
                _dbSet.AttachRange(entities);

                foreach (TEntity entity in entities)
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                }

                return entities;
            }, cancellationToken);
}