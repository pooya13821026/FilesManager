using FilesManager.Application.Common.Exceptions;
using FilesManager.Application.Contracts.Persistence;
using FilesManager.Application.Contracts.Persistence.Common;
using FilesManager.Domain.Common;
using FilesManager.Domain.Enum.Order;
using FilesManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FilesManager.Infrastructure.Implementation.Repositories;

public class ReadRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
    where TEntity : class, IEntityBase<TKey>
{
    protected readonly ApplicationContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public ReadRepository(ApplicationContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Tuple<List<IOrderBy>, OrderTypeEnum?>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? thenIncludes = null,
            bool disableTracking = true)
    {
        try
        {
            var query = DbSet.AsQueryable();
            if (disableTracking) query = query.AsNoTracking();
            if (thenIncludes != null) query = thenIncludes(query);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
            {
                foreach (var orderByItem in orderBy.Item1)
                {
                    query = orderBy.Item2 == OrderTypeEnum.Descending ?
                        Queryable.OrderByDescending(query, orderByItem.Expression) :
                        Queryable.OrderBy(query, orderByItem.Expression);
                }
            }

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new ContextException(typeof(TEntity).Name, ex);
        }
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        try
        {
            return (await GetAsync(
                    predicate: x => x.Id!.Equals(id),
                    disableTracking: false))
                .ToList()
                .FirstOrDefault();
        }
        catch (Exception ex)
        {
            throw new ContextException(typeof(TEntity).Name, ex);
        }
    }
}