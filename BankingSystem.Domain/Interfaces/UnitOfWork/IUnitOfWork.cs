using BankingSystem.Domain.Interfaces.GenericRepository;

namespace BankingSystem.Domain.Interfaces.UnitOfWork
{
	public interface IUnitOfWork
	{
		IGenericRepository<TEntity> GetRepository<TEntity>()
			where TEntity : class;

		Task CommitAsync();

	}
}
