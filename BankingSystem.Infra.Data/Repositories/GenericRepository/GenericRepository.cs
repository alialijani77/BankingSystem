using BankingSystem.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankingSystem.Infra.Data.Repositories.GenericRepository
{
	public class GenericRepository<TEntity> : Domain.Interfaces.GenericRepository.IGenericRepository<TEntity> where TEntity : class

	{
		private readonly BankingSystemDbContext _context;
		private DbSet<TEntity> _dbSet;

		#region ctor
		public GenericRepository(BankingSystemDbContext context)
		{
			_context = context;
			this._dbSet = _context.Set<TEntity>();
		}
		#endregion

		public virtual IEnumerable<TEntity> Get(
		   Expression<Func<TEntity, bool>> filter = null,
		   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		   string includeProperties = "")
		{
			IQueryable<TEntity> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public virtual async Task<TEntity> GetByID(object id)
		{
			return await _dbSet.FindAsync(id);
		}

		public virtual async Task Insert(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await CommitAsync();
		}

		public virtual async Task Update(TEntity entityToUpdate)
		{
			_dbSet.Update(entityToUpdate);
			await CommitAsync();
		}
		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync(CancellationToken.None);
		}
	}
}

