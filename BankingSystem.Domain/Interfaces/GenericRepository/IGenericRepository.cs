using System.Linq.Expressions;


namespace BankingSystem.Domain.Interfaces.GenericRepository
{
	 public interface IGenericRepository<TEntity>
	{
		IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		 string includeProperties = "");

		Task<TEntity> GetByID(object id);

		Task Insert(TEntity entity);

		Task Update(TEntity entityToUpdate);

		Task CommitAsync();
	}
}
