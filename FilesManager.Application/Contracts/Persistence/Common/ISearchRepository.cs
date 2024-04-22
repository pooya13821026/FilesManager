using FilesManager.Domain.Common;
using FilesManager.Domain.Enum.Order;
using System.Linq.Expressions;

namespace FilesManager.Application.Contracts.Persistence.Common;
public interface ISearchRepository<TKey, TEntity, TList, in TListItem, in TSearch>
    where TEntity : IEntityBase<TKey>
    where TListItem : class
    //where TList : BaseListTable<TListItem>
    //where TSearch : BaseTablePaging<TKey>
{

    Dictionary<string, IOrderBy> OrderFunctions { get; init; }
    Task<TList> Search(TSearch search);
    Expression<Func<TEntity, bool>>? GetExpression(TSearch search);
    Tuple<List<IOrderBy>, OrderTypeEnum?>? GetOrder(TSearch search);
    //Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? GetIncludes();

}
