using BankingSystem.Domain.Interfaces.GenericRepository;
using BankingSystem.Domain.Interfaces.UnitOfWork;
using BankingSystem.Infra.Data.Context;
using BankingSystem.Infra.Data.Repositories.GenericRepository;

namespace BankingSystem.Infra.Data.Repositories.UnitOfWork
{
	public sealed class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly BankingSystemDbContext _context;

		private Dictionary<Type, object> repos;

		#region ctor
		public UnitOfWork(BankingSystemDbContext context)
        {
            _context = context;
        }
		#endregion

		public IGenericRepository<TEntity> GetRepository<TEntity>()
			where TEntity : class
		{
			if (repos == null)
			{
				repos = new Dictionary<Type, object>();
			}

			var type = typeof(TEntity);
			if (!repos.ContainsKey(type))
			{
				repos[type] = new GenericRepository<TEntity>(_context);
			}

			return (IGenericRepository<TEntity>)repos[type];
		}

		public async Task CommitAsync()
		{
			 await _context.SaveChangesAsync(CancellationToken.None);
		}

		public void Dispose()
		{
			Dispose();
			GC.SuppressFinalize(obj: this);
		}
	}
}
