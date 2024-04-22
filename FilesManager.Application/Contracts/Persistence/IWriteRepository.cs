using FilesManager.Domain.Common;

namespace FilesManager.Application.Contracts.Persistence;
public interface IWriteRepository<in TEntity, in TKey> where TEntity : IEntityBase<TKey>
{
    void Add(TEntity entity);
    void Add(params TEntity[] entities);
    void Add(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Update(params TEntity[] entities);
    void Update(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void Delete(params TEntity[] entities);
    void Delete(IEnumerable<TEntity> entities);
    Task Delete(TKey id);
    Task<int> CommitAsync();
}

