using FilesManager.Application.Contracts.Persistence.Common;
using System.Linq.Expressions;

namespace FilesManager.Infrastructure.Implementation.Common;
public class OrderBy<TEntity, TProperty> : IOrderBy
{
    private readonly Expression<Func<TEntity, TProperty>> _expression;

    public OrderBy(Expression<Func<TEntity, TProperty>> expression)
    {
        _expression = expression;
    }

    public dynamic Expression => _expression;
}
