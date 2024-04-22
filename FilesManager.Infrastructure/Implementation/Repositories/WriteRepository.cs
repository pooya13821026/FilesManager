using FilesManager.Application.Common.Exceptions;
using FilesManager.Application.Contracts.Persistence;
using FilesManager.Domain.Common;
using FilesManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FilesManager.Infrastructure.Implementation.Repositories;

public class WriteRepository<TEntity, TKey> : ReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey>
	where TEntity : class, IEntityBase<TKey>
{
	public WriteRepository(ApplicationContext context) :
		base(context)
	{ }

	public void Add(TEntity entity)
	{
		try
		{
			Context.Entry(entity).State = EntityState.Added;
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Add(params TEntity[] entities)
	{
		try
		{
            foreach (var entity in entities)
            {
                Context.Entry(entity).State = EntityState.Added;
            }
        }
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Add(IEnumerable<TEntity> entities)
	{
		try
		{
            foreach (var entity in entities)
            {
			    Context.Entry(entity).State = EntityState.Added;
            }
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Update(TEntity entity)
	{
		try
		{
			Context.Entry(entity).State = EntityState.Modified;
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Update(params TEntity[] entities)
	{
		try
		{
			Context.Entry(entities).State = EntityState.Modified;
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Update(IEnumerable<TEntity> entities)
	{
		try
		{
			Context.Entry(entities).State = EntityState.Modified;
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Delete(TEntity entity)
	{
		try
		{
			entity.IsDeleted = true;
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Delete(params TEntity[] entities)
	{
		try
		{
			entities.ToList().ForEach(e => e.IsDeleted = true);
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public void Delete(IEnumerable<TEntity> entities)
	{
		try
		{
			entities.ToList().ForEach(e => e.IsDeleted = true);
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public async Task Delete(TKey id)
	{
		try
		{
			var entity = await GetByIdAsync(id);
			if (entity == null) throw new ArgumentNullException();
			Delete(entity);
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}

	public Task<int> CommitAsync()
	{
		try
		{
			return Context.SaveChangesAsync();
		}
		catch (Exception e)
		{
			throw new ContextException(typeof(TEntity).Name, e);
		}
	}
}