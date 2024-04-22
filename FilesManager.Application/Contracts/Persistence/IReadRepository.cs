using FilesManager.Application.Contracts.Persistence.Common;
using FilesManager.Domain.Common;
using FilesManager.Domain.Enum.Order;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilesManager.Application.Contracts.Persistence
{
    public interface IReadRepository<TEntity, in TKey> where TEntity : IEntityBase<TKey>
    {
        Task<IReadOnlyList<TEntity>> GetAsync(
                Expression<Func<TEntity, bool>>? predicate = null,
                Tuple<List<IOrderBy>, OrderTypeEnum?>? orderBy = null,
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? thenIncludes = null,
                bool disableTracking = true);

        Task<TEntity?> GetByIdAsync(TKey id);
    }
}
